
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EcoRecruit.Application.Recruitment.JobLanguages.Dto;
using EcoRecruit.Recruitment.JobLanguages.Dto;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.JobLanguages
{
    public interface IJobLanguageAppService : IApplicationService
    {
        Task<JobLanguageDto> CreateAsync(CreateJobLanguageDto JobLanguage);

        Task<JobLanguageDto> UpdateAsync(JobLanguageDto JobLanguage);

        Task  DeleteAsync(long id);

        Task<JobLanguageDto> GetJobLanguageAsync(long id);

        Task<PagedResultDto<JobLanguageDto>> GetJobLanguagesAsync(PagedJobLanguageResultRequestDto input);

      
    }
}
