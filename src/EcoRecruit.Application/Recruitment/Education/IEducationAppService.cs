
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EcoRecruit.Application.Recruitment.Educations.Dto;
using EcoRecruit.Recruitment.Educations.Dto;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Educations
{
    public interface IEducationAppService : IApplicationService
    {
        Task<EducationDto> CreateAsync(CreateEducationDto Education);

        Task<EducationDto> UpdateAsync(EducationDto Education);

        Task  DeleteAsync(long id);

        Task<EducationDto> GetEducationAsync(long id);

        Task<PagedResultDto<EducationDto>> GetEducationsAsync(PagedEducationResultRequestDto input);

      
    }
}
