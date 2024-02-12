using Abp.Domain.Services;
using EcoRecruit.Recruitment.Applicants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Checks.Interfaces
{
    public interface ICheckManager : IDomainService
    {
        Task<Check> GetByIdAsync(int id);
        IQueryable<Check> GetAll();
        Task<Check> CreateAsync(Check value);
        Task<Check> UpdateAsync(Check value);
        Task DeleteAsync(int id);

    }
}