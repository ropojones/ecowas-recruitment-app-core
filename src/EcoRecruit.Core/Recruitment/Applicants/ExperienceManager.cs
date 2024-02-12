using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Runtime.Session;
using EcoRecruit.Recruitment.Applicants.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Applicants
{
    public class ExperienceManager: DomainService, IExperienceManager
    {
        private readonly IRepository<ApplicantExperience, long> _repository;
        public IAbpSession AbpSession { get; set; }
        private readonly ILogger<ExperienceManager> _logger; // 
        public ExperienceManager(IRepository<ApplicantExperience, long> repository, ILogger<ExperienceManager> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<ApplicantExperience> GetByIdAsync(long id)
        {
            try
            {
                return await _repository.GetAsync(id);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to create experience.");
                throw new ApplicationException("Failed to create experience.", ex);
            }

        }

        public IQueryable<ApplicantExperience> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to get the list of experiences.");
                throw new ApplicationException("Failed to get the list of experiences.", ex);
            }

        }

        public async Task<ApplicantExperience> CreateAsync(ApplicantExperience value)
        {
            try
            {
                return await _repository.InsertAsync(value);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to create experience.");
                throw new ApplicationException("Failed to create experience.", ex);
            }

        }

        public async Task<ApplicantExperience> UpdateAsync(ApplicantExperience value)
        {

            try
            {
                return await _repository.UpdateAsync(value);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to update experience.");
                throw new ApplicationException("Failed to update experience.", ex);
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
                _logger.LogError(ex, "Failed to delete experience.");
                throw new ApplicationException("Failed to delete experience.", ex);
            }

        }

    }
}