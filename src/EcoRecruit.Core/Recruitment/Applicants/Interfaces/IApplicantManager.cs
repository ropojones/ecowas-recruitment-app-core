using Abp.Domain.Services;
using EcoRecruit.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Applicants.Interfaces
{
    public interface IApplicantManager: IDomainService
    {
       Task<Applicant> GetByUserIdAsync(long userId);
        Task<Applicant> GetByIdAsync(long id);
        IQueryable<Applicant> GetAll();
        Task<Applicant> CreateAsync(Applicant value);
        Task<Applicant> UpdateAsync(Applicant value);
        Task DeleteAsync(long id);
       Task<bool> IsCreated(long userId);






    }
}