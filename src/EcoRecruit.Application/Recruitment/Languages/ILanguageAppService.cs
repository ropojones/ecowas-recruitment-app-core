
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EcoRecruit.Application.Recruitment.Languages.Dto;
using EcoRecruit.Recruitment.Languages.Dto;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Languages
{
    public interface ILanguageAppService : IApplicationService
    {
        Task<LanguageDto> CreateAsync(CreateLanguageDto Language);

        Task<LanguageDto> UpdateAsync(LanguageDto Language);

        Task  DeleteAsync(long id);

        Task<LanguageDto> GetLanguageAsync(long id);

        Task<PagedResultDto<LanguageDto>> GetLanguagesAsync(PagedLanguageResultRequestDto input);

      
    }
}
