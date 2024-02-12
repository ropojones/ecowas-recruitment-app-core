using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Jobs.Interfaces
{
    public interface IJobManager: IDomainService
    {
        Task<Job> GetByIdAsync(int id);
        IQueryable <Job> GetAll();
        Task<Job> CreateAsync(Job value);
        Task<Job> UpdateAsync(Job value);
        Task DeleteAsync(int id);
    }
}