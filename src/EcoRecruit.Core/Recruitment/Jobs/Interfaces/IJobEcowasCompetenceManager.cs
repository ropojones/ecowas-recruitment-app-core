using Abp.Domain.Services;
using EcoRecruit.Recruitment.Applicants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Jobs.Interfaces
{
    public interface IJobEcowasCompetenceManager : IDomainService
    {

        Task<JobEcowasCompetence> GetByIdAsync(long id);
        IQueryable<JobEcowasCompetence> GetAll();
        Task<JobEcowasCompetence> CreateAsync(JobEcowasCompetence value);
        Task<JobEcowasCompetence> UpdateAsync(JobEcowasCompetence value);
        Task DeleteAsync(long id);
    }
}