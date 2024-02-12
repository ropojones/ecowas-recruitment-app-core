using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Runtime.Session;
using EcoRecruit.Recruitment.Applicants;
using EcoRecruit.Recruitment.Jobs.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Jobs
{
    public class JobEcowasCompetenceManager : DomainService, IJobEcowasCompetenceManager
    {
        private readonly IRepository<JobEcowasCompetence, long> _repository;
        public IAbpSession AbpSession { get; set; }
        private readonly ILogger<JobEcowasCompetenceManager> _logger; // 
        public JobEcowasCompetenceManager(IRepository<JobEcowasCompetence, long> repository, ILogger<JobEcowasCompetenceManager> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<JobEcowasCompetence> GetByIdAsync(long id)
        {
            try
            {
                return await _repository.GetAsync(id);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to create competence.");
                throw new ApplicationException("Failed to create competence.", ex);
            }

        }

        public IQueryable<JobEcowasCompetence> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to get the list of competences.");
                throw new ApplicationException("Failed to get the list of competences.", ex);
            }

        }

        public async Task<JobEcowasCompetence> CreateAsync(JobEcowasCompetence value)
        {
            try
            {
                return await _repository.InsertAsync(value);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to create competence.");
                throw new ApplicationException("Failed to create competence.", ex);
            }

        }

        public async Task<JobEcowasCompetence> UpdateAsync(JobEcowasCompetence value)
        {

            try
            {
                return await _repository.UpdateAsync(value);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to update competence.");
                throw new ApplicationException("Failed to update competence.", ex);
            }

        }

        public async Task DeleteAsync(long id)
        {
            try
            {
                await _repository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to delete competence.");
                throw new ApplicationException("Failed to delete competence.", ex);
            }

        }

    }
}