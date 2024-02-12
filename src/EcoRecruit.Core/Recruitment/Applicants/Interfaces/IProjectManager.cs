using Abp.Domain.Services;
using EcoRecruit.Recruitment.Jobs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Applicants.Interfaces
{
    public interface IProjectManager : IDomainService
    {
        Task<ApplicantProject> GetByIdAsync(long id);
        IQueryable<ApplicantProject> GetAll();
        Task<ApplicantProject> CreateAsync(ApplicantProject value);
        Task<ApplicantProject> UpdateAsync(ApplicantProject value);
        Task DeleteAsync(long id);

    }
}