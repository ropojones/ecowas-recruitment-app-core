using Abp.Domain.Services;
using System.Linq;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Applicants.Interfaces
{
    public interface ICertificateAwardedManager : IDomainService
    {

        Task<ApplicantCertificateAwarded> GetByIdAsync(long id);
        IQueryable<ApplicantCertificateAwarded> GetAll();
        Task<ApplicantCertificateAwarded> CreateAsync(ApplicantCertificateAwarded value);
        Task<ApplicantCertificateAwarded> UpdateAsync(ApplicantCertificateAwarded value);
        Task DeleteAsync(long id);

    }
}