using Abp.Domain.Services;
using EcoRecruit.Recruitment.Jobs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Applicants.Interfaces
{
    public interface IExperienceManager : IDomainService
    {
        Task<ApplicantExperience> GetByIdAsync(long id);
        IQueryable<ApplicantExperience> GetAll();
        Task<ApplicantExperience> CreateAsync(ApplicantExperience value);
        Task<ApplicantExperience> UpdateAsync(ApplicantExperience value);
        Task DeleteAsync(long id);

    }
}