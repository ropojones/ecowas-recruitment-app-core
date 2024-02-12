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
    public class JobLanguageManager: DomainService, IJobLanguageManager
    {
        private readonly IRepository<JobLanguage, long> _repository;
        public IAbpSession AbpSession { get; set; }
        private readonly ILogger<JobLanguageManager> _logger; // 
        public JobLanguageManager(IRepository<JobLanguage, long> repository, ILogger<JobLanguageManager> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<JobLanguage> GetByIdAsync(long id)
        {
            try
            {
                return await _repository.GetAsync(id);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to create job language.");
                throw new ApplicationException("Failed to create job language.", ex);
            }

        }

        public IQueryable<JobLanguage> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to get the list of job languages.");
                throw new ApplicationException("Failed to get the list of job languages.", ex);
            }

        }

        public async Task<JobLanguage> CreateAsync(JobLanguage value)
        {
            try
            {
                return await _repository.InsertAsync(value);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to create job language.");
                throw new ApplicationException("Failed to create job language.", ex);
            }

        }

        public async Task<JobLanguage> UpdateAsync(JobLanguage value)
        {

            try
            {
                return await _repository.UpdateAsync(value);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to update job language.");
                throw new ApplicationException("Failed to update job language.", ex);
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
                _logger.LogError(ex, "Failed to delete job language.");
                throw new ApplicationException("Failed to delete job language.", ex);
            }

        }

    }
}