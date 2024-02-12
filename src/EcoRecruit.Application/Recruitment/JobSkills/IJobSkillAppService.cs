
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EcoRecruit.Application.Recruitment.JobSkills.Dto;
using EcoRecruit.Recruitment.JobSkills.Dto;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.JobSkills
{
    public interface IJobSkillAppService : IApplicationService
    {
        Task<JobSkillDto> CreateAsync(CreateJobSkillDto JobSkill);

        Task<JobSkillDto> UpdateAsync(JobSkillDto JobSkill);

        Task  DeleteAsync(long id);

        Task<JobSkillDto> GetJobSkillAsync(long id);

        Task<PagedResultDto<JobSkillDto>> GetJobSkillsAsync(PagedJobSkillResultRequestDto input);      
    }
}
