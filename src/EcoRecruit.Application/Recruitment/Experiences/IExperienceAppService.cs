
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EcoRecruit.Application.Recruitment.Experiences.Dto;
using EcoRecruit.Recruitment.Experiences.Dto;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Experiences
{
    public interface IExperienceAppService : IApplicationService
    {
        Task<ExperienceDto> CreateAsync(CreateExperienceDto Experience);

        Task<ExperienceDto> UpdateAsync(ExperienceDto Experience);

        Task  DeleteAsync(long id);

        Task<ExperienceDto> GetExperienceAsync(long id);

        Task<PagedResultDto<ExperienceDto>> GetExperiencesAsync(PagedExperienceResultRequestDto input);

      
    }
}
