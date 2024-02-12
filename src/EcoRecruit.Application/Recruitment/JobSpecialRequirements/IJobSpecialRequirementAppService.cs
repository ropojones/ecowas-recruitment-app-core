
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EcoRecruit.Application.Recruitment.JobSpecialRequirements.Dto;
using EcoRecruit.Recruitment.JobSpecialRequirements.Dto;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.JobSpecialRequirements
{
    public interface IJobSpecialRequirementAppService : IApplicationService
    {
        Task<JobSpecialRequirementDto> CreateAsync(CreateJobSpecialRequirementDto JobSpecialRequirement);

        Task<JobSpecialRequirementDto> UpdateAsync(JobSpecialRequirementDto JobSpecialRequirement);

        Task  DeleteAsync(long id);

        Task<JobSpecialRequirementDto> GetJobSpecialRequirementAsync(long id);

        Task<PagedResultDto<JobSpecialRequirementDto>> GetJobSpecialRequirementsAsync(PagedJobSpecialRequirementResultRequestDto input);

      
    }
}
