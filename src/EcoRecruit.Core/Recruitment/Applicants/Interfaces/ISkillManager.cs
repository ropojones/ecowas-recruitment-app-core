using Abp.Domain.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Applicants.Interfaces
{
    public interface ISkillManager : IDomainService
    {
        Task<ApplicantSkill> GetByIdAsync(long id);
        IQueryable<ApplicantSkill> GetAll();
        Task<ApplicantSkill> CreateAsync(ApplicantSkill value);
        Task<ApplicantSkill> UpdateAsync(ApplicantSkill value);
        Task DeleteAsync(long id);

    }
}