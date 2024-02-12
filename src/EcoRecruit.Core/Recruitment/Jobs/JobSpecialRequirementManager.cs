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
    public class JobSpecialRequirementManager: DomainService, IJobSpecialRequirementManager
    {
        private readonly IRepository<JobSpecialRequirement, long> _repository;
        public IAbpSession AbpSession { get; set; }
        private readonly ILogger<JobSpecialRequirementManager> _logger; // 
        public JobSpecialRequirementManager(IRepository<JobSpecialRequirement, long> repository, ILogger<JobSpecialRequirementManager> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<JobSpecialRequirement> GetByIdAsync(long id)
        {
            try
            {
                return await _repository.GetAsync(id);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to create job special requirement.");
                throw new ApplicationException("Failed to create job special requirement.", ex);
            }

        }

        public IQueryable<JobSpecialRequirement> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to get the list of job special requirements.");
                throw new ApplicationException("Failed to get the list of job special requirements.", ex);
            }

        }

        public async Task<JobSpecialRequirement> CreateAsync(JobSpecialRequirement value)
        {
            try
            {
                return await _repository.InsertAsync(value);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to create job special requirement.");
                throw new ApplicationException("Failed to create job special requirement.", ex);
            }

        }

        public async Task<JobSpecialRequirement> UpdateAsync(JobSpecialRequirement value)
        {

            try
            {
                return await _repository.UpdateAsync(value);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to update job special requirement.");
                throw new ApplicationException("Failed to update job special requirement.", ex);
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
                _logger.LogError(ex, "Failed to delete job special requirement.");
                throw new ApplicationException("Failed to delete job special requirement.", ex);
            }

        }

    }
}