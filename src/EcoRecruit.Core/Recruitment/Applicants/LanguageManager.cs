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
    public class LanguageManager : DomainService, ILanguageManager
    {
        private readonly IRepository<ApplicantLanguage, long> _repository;
        public IAbpSession AbpSession { get; set; }
        private readonly ILogger<LanguageManager> _logger; // 
        public LanguageManager(IRepository<ApplicantLanguage, long> repository, ILogger<LanguageManager> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<ApplicantLanguage> GetByIdAsync(long id)
        {
            try
            {
                return await _repository.GetAsync(id);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to create language.");
                throw new ApplicationException("Failed to create language.", ex);
            }

        }

        public IQueryable<ApplicantLanguage> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to get the list of languages.");
                throw new ApplicationException("Failed to get the list of languages.", ex);
            }

        }

        public async Task<ApplicantLanguage> CreateAsync(ApplicantLanguage value)
        {
            try
            {
                return await _repository.InsertAsync(value);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to create language.");
                throw new ApplicationException("Failed to create language.", ex);
            }

        }

        public async Task<ApplicantLanguage> UpdateAsync(ApplicantLanguage value)
        {

            try
            {
                return await _repository.UpdateAsync(value);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to update language.");
                throw new ApplicationException("Failed to update language.", ex);
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
                _logger.LogError(ex, "Failed to delete language.");
                throw new ApplicationException("Failed to delete language.", ex);
            }

        }

    }
}