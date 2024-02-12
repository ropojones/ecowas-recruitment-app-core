using Abp.Domain.Services;
using EcoRecruit.Recruitment.Jobs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Applicants.Interfaces
{
    public interface IEducationManager : IDomainService
    {
        Task<ApplicantEducation> GetByIdAsync(long id);
        IQueryable<ApplicantEducation> GetAll();
        Task<ApplicantEducation> CreateAsync(ApplicantEducation value);
        Task<ApplicantEducation> UpdateAsync(ApplicantEducation value);
        Task DeleteAsync(long id);
    }
}