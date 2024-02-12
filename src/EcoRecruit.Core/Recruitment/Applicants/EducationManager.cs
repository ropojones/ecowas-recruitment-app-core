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
    public class EducationManager: DomainService, IEducationManager
    {
        private readonly IRepository<ApplicantEducation, long> _repository;
        public IAbpSession AbpSession { get; set; }
        private readonly ILogger<EducationManager> _logger; // 
        public EducationManager(IRepository<ApplicantEducation, long> repository, ILogger<EducationManager> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<ApplicantEducation> GetByIdAsync(long id)
        {
            try
            {
                return await _repository.GetAsync(id);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to create education.");
                throw new ApplicationException("Failed to create education.", ex);
            }

        }

        public IQueryable<ApplicantEducation> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to get the list of educations.");
                throw new ApplicationException("Failed to get the list of educations.", ex);
            }

        }

        public async Task<ApplicantEducation> CreateAsync(ApplicantEducation value)
        {
            try
            {
                return await _repository.InsertAsync(value);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to create education.");
                throw new ApplicationException("Failed to create education.", ex);
            }

        }

        public async Task<ApplicantEducation> UpdateAsync(ApplicantEducation value)
        {

            try
            {
                return await _repository.UpdateAsync(value);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to update education.");
                throw new ApplicationException("Failed to update education.", ex);
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
                _logger.LogError(ex, "Failed to delete education.");
                throw new ApplicationException("Failed to delete education.", ex);
            }

        }

    }
}