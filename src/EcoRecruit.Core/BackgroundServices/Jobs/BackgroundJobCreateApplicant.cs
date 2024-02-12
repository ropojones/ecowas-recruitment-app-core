using Abp.Domain.Repositories;
using EcoRecruit.Authorization.Users;
using EcoRecruit.Recruitment.Applicants;
using Quartz;
using System.Threading.Tasks;
namespace EcoRecruit.Core.BackgroundServices
{
    public class BackgroundJobCreateApplicant : IJob
    {
        private IRepository<Applicant, long> _repositoryApplicant;

       public BackgroundJobCreateApplicant()
        {

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
 
            _repositoryApplicant.InsertOrUpdate(applicant);

            return Task.CompletedTask;
        }
    }
}
