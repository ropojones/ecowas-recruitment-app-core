using System.Threading.Tasks;
using Abp.Configuration;
using Abp.Extensions;
using Abp.Zero.Configuration;
using EcoRecruit.Authorization.Accounts.Dto;
using EcoRecruit.Authorization.Users;
using EcoRecruit.BackgroundServices.Jobs;
using Quartz.Impl;
using Quartz;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using System;
using EcoRecruit.Recruitment.Applicants;
using Abp.Net.Mail;

namespace EcoRecruit.Authorization.Accounts
{
    public class AccountAppService : EcoRecruitAppServiceBase, IAccountAppService
    {
        // from: http://regexlib.com/REDetails.aspx?regexp_id=1923
        public const string PasswordRegex = "(?=^.{8,}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\\s)[0-9a-zA-Z!@#$%^&*()]*$";



        private readonly ApplicantManager _applicantManager;
        private readonly UserRegistrationManager _userRegistrationManager;
        private readonly IEmailSender _emailSender;
        public AccountAppService(UserRegistrationManager userRegistrationManager, ApplicantManager applicantManager, IEmailSender emailSender)
        {
            _userRegistrationManager = userRegistrationManager;
            _applicantManager = applicantManager;
            _emailSender = emailSender;
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
                false,// Assumed email address is always confirmed. Change this if you want to implement email confirmation.
                input.PhoneNumber
            );           

            var isEmailConfirmationRequiredForLogin = await SettingManager.GetSettingValueAsync<bool>(AbpZeroSettingNames.UserManagement.IsEmailConfirmationRequiredForLogin);

            if (user != null)
            {
                var applicant = new Applicant
                {
                    FirstName = user.Name,
                    LastName = user.Surname,
                    Phone = user.PhoneNumber,
                    Email = user.EmailAddress,
                    UserId = user.Id,


                };
                await _applicantManager.CreateAsync(applicant);

               
            }

            return new RegisterOutput
            {
                CanLogin = user.IsActive && (user.IsEmailConfirmed || !isEmailConfirmationRequiredForLogin)
            };
        }
       



    }
}
