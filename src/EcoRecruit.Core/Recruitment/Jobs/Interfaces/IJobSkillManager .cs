using Abp.Domain.Services;
using EcoRecruit.Recruitment.Applicants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Jobs.Interfaces
{
    public interface IJobSkillManager : IDomainService
    {
        Task<JobSkill> GetByIdAsync(long id);
        IQueryable<JobSkill> GetAll();
        Task<JobSkill> CreateAsync(JobSkill value);
        Task<JobSkill> UpdateAsync(JobSkill value);
        Task DeleteAsync(long id);
    }
}