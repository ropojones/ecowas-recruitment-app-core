using Abp.Domain.Services;
using EcoRecruit.Recruitment.Applicants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Countries.Interfaces
{
    public interface ICountryManager: IDomainService
    {
        Task<Country> GetByIdAsync(int id);
        IQueryable<Country> GetAll();
        Task<Country> CreateAsync(Country value);
        Task<Country> UpdateAsync(Country value);
        Task DeleteAsync(int id);
    }
}