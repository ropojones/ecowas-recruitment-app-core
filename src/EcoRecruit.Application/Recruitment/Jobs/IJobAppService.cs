using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Services;
using EcoRecruit.Application.Recruitment.Experiences.Dto;
using EcoRecruit.Application.Recruitment.Jobs.Dto;
using EcoRecruit.Recruitment.Experiences.Dto;
using EcoRecruit.Recruitment.Jobs.Dto;
using System.Linq;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Jobs
{
    public interface IJobAppService : IApplicationService
    {
        Task<JobDto> CreateAsync(CreateJobDto job);

        Task<JobDto> UpdateAsync(JobDto job);

        Task  DeleteAsync(int id);

        Task<JobDto> GetJobAsync(int id);

        Task<JobDto> GetJobByRefNoAsync(string jobRefNo);

        Task<PagedResultDto<JobDto>> GetJobsAsync(PagedJobResultRequestDto input);
      
    }
}
