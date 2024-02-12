using Abp.Domain.Services;
using EcoRecruit.Recruitment.Applicants;
using EcoRecruit.Recruitment.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Applicants.Interfaces
{
    public interface ICoverLetterManager: IDomainService
    {
        Task<ApplicantCoverLetter> GetByIdAsync(long id);
        IQueryable<ApplicantCoverLetter> GetAll();
        Task<ApplicantCoverLetter> CreateAsync(ApplicantCoverLetter value);
        Task<ApplicantCoverLetter> UpdateAsync(ApplicantCoverLetter value);
        Task DeleteAsync(long id);

    }
}