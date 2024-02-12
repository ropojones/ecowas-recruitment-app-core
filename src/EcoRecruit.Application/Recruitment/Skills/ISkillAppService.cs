
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EcoRecruit.Application.Recruitment.Skills.Dto;
using EcoRecruit.Recruitment.Skills.Dto;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Skills
{
    public interface ISkillAppService : IApplicationService
    {
        Task<SkillDto> CreateAsync(CreateSkillDto Skill);

        Task<SkillDto> UpdateAsync(SkillDto Skill);

        Task  DeleteAsync(long id);

        Task<SkillDto> GetSkillAsync(long id);

        Task<PagedResultDto<SkillDto>> GetSkillsAsync(PagedSkillResultRequestDto input);

      
    }
}
