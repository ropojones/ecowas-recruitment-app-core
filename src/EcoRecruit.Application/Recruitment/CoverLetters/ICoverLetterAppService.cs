
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EcoRecruit.Application.Recruitment.CoverLetters.Dto;
using EcoRecruit.Recruitment.CoverLetters.Dto;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.CoverLetters
{
    public interface ICoverLetterAppService : IApplicationService
    {
        Task<CoverLetterDto> CreateAsync(CreateCoverLetterDto CoverLetter);

        Task<CoverLetterDto> UpdateAsync(CoverLetterDto CoverLetter);

        Task  DeleteAsync(long id);

        Task<CoverLetterDto> GetCoverLetterAsync(long id);

        Task<PagedResultDto<CoverLetterDto>> GetCoverLettersAsync(PagedCoverLetterResultRequestDto input);

      
    }
}
