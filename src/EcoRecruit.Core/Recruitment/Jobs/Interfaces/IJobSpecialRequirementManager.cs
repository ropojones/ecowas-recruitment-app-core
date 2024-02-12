using Abp.Domain.Services;
using EcoRecruit.Recruitment.Applicants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Jobs.Interfaces
{
    public interface IJobSpecialRequirementManager: IDomainService
    {
        Task<JobSpecialRequirement> GetByIdAsync(long id);
        IQueryable<JobSpecialRequirement> GetAll();
        Task<JobSpecialRequirement> CreateAsync(JobSpecialRequirement value);
        Task<JobSpecialRequirement> UpdateAsync(JobSpecialRequirement value);
        Task DeleteAsync(long id);
    }
}