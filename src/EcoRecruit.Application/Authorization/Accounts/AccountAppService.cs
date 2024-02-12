using System.Threading.Tasks;
using Abp.Configuration;
using Abp.Extensions;
using Abp.Zero.Configuration;
using EcoRecruit.Authorization.Accounts.Dto;
using EcoRecruit.Authorization.Users;
using EcoRecruit.BackgroundServices.Jobs;
using Quartz.Impl;
using Quartz;

namespace EcoRecruit.Authorization.Accounts
{
    public class AccountAppService : EcoRecruitAppServiceBase, IAccountAppService
    {
        // from: http://regexlib.com/REDetails.aspx?regexp_id=1923
        public const string PasswordRegex = "(?=^.{8,}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\\s)[0-9a-zA-Z!@#$%^&*()]*$";
        
        
        
        
        private readonly UserRegistrationManager _userRegistrationManager;
        private readonly IScheduler _scheduler;

        public AccountAppService(UserRegistrationManager userRegistrationManager, IScheduler scheduler)
        {
            _userRegistrationManager = userRegistrationManager;
            _scheduler = scheduler;

        }

        public async Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input)
        {
            var tenant = await TenantManager.FindByTenancyNameAsync(input.TenancyName);
            if (tenant == null)
            {
                return new IsTenantAvailableOutput(TenantAvailabilityState.NotFound);
            }

            if (!tenant.IsActive)
            {
                return new IsTenantAvailableOutput(TenantAvailabilityState.InActive);
            }

            return new IsTenantAvailableOutput(TenantAvailabilityState.Available, tenant.Id);
        }

        public async Task<RegisterOutput> Register(RegisterInput input)
        {
            var user = await _userRegistrationManager.RegisterAsync(
                input.Name,
                input.Surname,
                input.EmailAddress,
                input.UserName,
                input.Password,
                false // Assumed email address is always confirmed. Change this if you want to implement email confirmation.
            );


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


            var isEmailConfirmationRequiredForLogin = await SettingManager.GetSettingValueAsync<bool>(AbpZeroSettingNames.UserManagement.IsEmailConfirmationRequiredForLogin);

            return new RegisterOutput
            {
                CanLogin = user.IsActive && (user.IsEmailConfirmed || !isEmailConfirmationRequiredForLogin)
            };
        }
    }
}
