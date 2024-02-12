using Abp.Domain.Services;
using EcoRecruit.Recruitment.Applicants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Jobs.Interfaces
{
    public interface IJobLanguageManager : IDomainService
    {

        Task<JobLanguage> GetByIdAsync(long id);
        IQueryable<JobLanguage> GetAll();
        Task<JobLanguage> CreateAsync(JobLanguage value);
        Task<JobLanguage> UpdateAsync(JobLanguage value);
        Task DeleteAsync(long id);
    }
}