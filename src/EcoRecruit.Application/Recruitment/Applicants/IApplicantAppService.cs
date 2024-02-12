using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EcoRecruit.Recruitment.Applicants.Dto;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Applicants
{
    public interface IApplicantAppService : IApplicationService
    {
        Task<ApplicantDto> CreateAsync(CreateApplicantDto applicant);

        Task<ApplicantDto> UpdateAsync(ApplicantDto applicant);

        Task DeleteAsync(long id);

        Task<bool> IsCreated(long userId);

        Task<ApplicantDto> GetApplicantAsync(long id);

        Task<ApplicantDto> GetApplicantUserIdAsync(long id);


        Task<ApplicantDto> GetApplicantByAppNoAsync(string appNo);

        Task<PagedResultDto<ApplicantDto>> GetApplicantsAsync(PagedApplicantResultRequestDto input);

    
    }
}
