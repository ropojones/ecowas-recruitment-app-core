using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EcoRecruit.Recruitment.CertificatesAwarded.Dto;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.CertificateAwardeds
{
    public interface ICertificateAwardedAppService : IApplicationService
    {
        Task<CertificateAwardedDto> CreateAsync(CreateCertificateAwardedDto CertificateAwarded);

        Task<CertificateAwardedDto> UpdateAsync(CertificateAwardedDto CertificateAwarded);

        Task  DeleteAsync(long id);

        Task<CertificateAwardedDto> GetCertificateAwardedAsync(long id);

        Task<PagedResultDto<CertificateAwardedDto>> GetCertificateAwardedsAsync(PagedCertificateAwardedResultRequestDto input);

      
    }
}
