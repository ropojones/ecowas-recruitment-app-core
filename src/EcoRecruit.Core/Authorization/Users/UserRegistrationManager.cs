using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Abp.Authorization.Users;
using Abp.Domain.Services;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using Abp.UI;
using EcoRecruit.Authorization.Roles;
using EcoRecruit.MultiTenancy;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using Quartz;
using Quartz.Impl;
using Microsoft.Extensions.Configuration;
using EcoRecruit.BackgroundServices.Jobs;

namespace EcoRecruit.Authorization.Users
{
    public class UserRegistrationManager : DomainService
    {
        public IAbpSession AbpSession { get; set; }

        private readonly TenantManager _tenantManager;
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IConfiguration _configuration;

        public UserRegistrationManager(
            TenantManager tenantManager,
            UserManager userManager,
            RoleManager roleManager,
            IPasswordHasher<User> passwordHasher,
            IConfiguration configuration)
        {
            _tenantManager = tenantManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _passwordHasher = passwordHasher;
            _configuration = configuration;

            AbpSession = NullAbpSession.Instance;
        }

        public async Task<User> RegisterAsync(string name, string surname, string emailAddress, string userName, string plainPassword, bool isEmailConfirmed)
        {

            CheckForTenant();

            var tenant = await GetActiveTenantAsync();

            var user = new User
            {
                TenantId = tenant.Id,
                Name = name,
                Surname = surname,
                EmailAddress = emailAddress,
                IsActive = false,
                UserName = userName,
                IsEmailConfirmed = isEmailConfirmed,
                Roles = new List<UserRole>()
            };

            user.SetNormalizedNames();

            foreach (var defaultRole in await _roleManager.Roles.Where(r => r.IsDefault).ToListAsync())
            {
                user.Roles.Add(new UserRole(tenant.Id, user.Id, defaultRole.Id));
            }

            await _userManager.InitializeOptionsAsync(tenant.Id);

            CheckErrors(await _userManager.CreateAsync(user, plainPassword));

            var emailConfirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            user.EmailConfirmationCode = emailConfirmationToken;

            await SendEmailConfirmationAsync(user, emailConfirmationToken);
            
            await CurrentUnitOfWork.SaveChangesAsync();

           
            return user;
        }
        public async Task SendEmailConfirmationAsync(User user, string token)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var callbackUrl = GenerateConfirmationLink(user.Id, token);

            StdSchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = await factory.GetScheduler();
             await scheduler.Start();

            var jobName = "job-create-applicant-" + user.Id.ToString();
            var jobGroup = "job-create-aplicant-group";
            var triggerName = "trigger-create-applicant-" + user.Id.ToString();
            var triggerGroup = "trigger-create-aplicant-group";

            IJobDetail sendConfirmMailJob = JobBuilder.Create<BackgroundJobCreateApplicant>()
                                                .WithIdentity(jobName, jobGroup)
                                                .UsingJobData("applicant-firstname", user.Name)
                                                .UsingJobData("applicant-lastname", user.Surname)
                                                .UsingJobData("applicant-email", user.EmailAddress)
                                                .UsingJobData("applicant-userid", user.Id.ToString())
                                                .UsingJobData("applicant-phonenumber", user.PhoneNumber)
                                                .UsingJobData("callbackurl", callbackUrl)
                                                .Build();

            ITrigger trigger = TriggerBuilder.Create().WithIdentity("trigger", "group1")
                                             .StartNow().Build();

             await scheduler.ScheduleJob(sendConfirmMailJob, trigger);

        }

        private string GenerateConfirmationLink(long userId, string code)
        {
            var baseUrl = _configuration.GetSection("App:ServerRootAddress");
            var encodedUserId = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(userId.ToString()));
            var encodedCode = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            return $"{baseUrl}/account/confirm-email?userId={encodedUserId}&code={encodedCode}";
        }

        private void CheckForTenant()
        {
            if (!AbpSession.TenantId.HasValue)
            {
                throw new InvalidOperationException("Can not register host users!");
            }
        }

        private async Task<Tenant> GetActiveTenantAsync()
        {
            if (!AbpSession.TenantId.HasValue)
            {
                return null;
            }

            return await GetActiveTenantAsync(AbpSession.TenantId.Value);
        }

        private async Task<Tenant> GetActiveTenantAsync(int tenantId)
        {
            var tenant = await _tenantManager.FindByIdAsync(tenantId);
            if (tenant == null)
            {
                throw new UserFriendlyException(L("UnknownTenantId{0}", tenantId));
            }

            if (!tenant.IsActive)
            {
                throw new UserFriendlyException(L("TenantIdIsNotActive{0}", tenantId));
            }

            return tenant;
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
