using Abp.Domain.Repositories;
using EcoRecruit.Authorization.Users;
using EcoRecruit.Recruitment.Applicants;
using EcoRecruit.Recruitment.Applicants.Interfaces;
using Quartz;
using System.Threading.Tasks;
namespace EcoRecruit.BackgroundServices.Jobs
{
    public class CreateApplicantJob : IJob
    {
       private IApplicantManager _applicantManager;
        public CreateApplicantJob(IApplicantManager applicantManager)
        {
          _applicantManager = applicantManager;
        }
        Task IJob.Execute(IJobExecutionContext context)
        {
            JobKey key = context.JobDetail.Key;
            JobDataMap dataMap = context.JobDetail.JobDataMap;

            var applicant = new Applicant
            {
                Email = dataMap.GetString("applicant-email"),
                FirstName = dataMap.GetString("applicant-firstname"),
                LastName = dataMap.GetString("applicant-lastname"),
                UserId = dataMap.GetLong("applicant-userid"),
                Phone = dataMap.GetString("applicant-phonenumber")
            };

             _applicantManager.CreateAsync(applicant);

            return Task.CompletedTask;
        }
    }
}
