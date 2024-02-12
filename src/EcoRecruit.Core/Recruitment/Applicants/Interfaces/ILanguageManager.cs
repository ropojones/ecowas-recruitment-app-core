using Abp.Domain.Services;
using EcoRecruit.Recruitment.Applicants;
using EcoRecruit.Recruitment.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Applicants.Interfaces
{
    public interface ILanguageManager: IDomainService
    {
        Task<ApplicantLanguage> GetByIdAsync(long id);
        IQueryable<ApplicantLanguage> GetAll();
        Task<ApplicantLanguage> CreateAsync(ApplicantLanguage value);
        Task<ApplicantLanguage> UpdateAsync(ApplicantLanguage value);
        Task DeleteAsync(long id);

    }
}