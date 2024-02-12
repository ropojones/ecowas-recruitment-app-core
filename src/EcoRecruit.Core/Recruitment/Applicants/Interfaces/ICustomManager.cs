using Abp.Domain.Services;
using EcoRecruit.Recruitment.Jobs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Applicants.Interfaces
{
    public interface ICustomManager : IDomainService
    {
        Task<ApplicantCustom> GetByIdAsync(long id);
        IQueryable<ApplicantCustom> GetAll();
        Task<ApplicantCustom> CreateAsync(ApplicantCustom value);
        Task<ApplicantCustom> UpdateAsync(ApplicantCustom value);
        Task DeleteAsync(long id);

    }
}