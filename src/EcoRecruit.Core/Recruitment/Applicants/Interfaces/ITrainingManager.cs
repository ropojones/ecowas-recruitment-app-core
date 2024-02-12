using Abp.Domain.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Applicants.Interfaces
{
    public interface ITrainingManager : IDomainService
    {
        Task<ApplicantTraining> GetByIdAsync(long id);
        IQueryable<ApplicantTraining> GetAll();
        Task<ApplicantTraining> CreateAsync(ApplicantTraining value);
        Task<ApplicantTraining> UpdateAsync(ApplicantTraining value);
        Task DeleteAsync(long id);

    }
}