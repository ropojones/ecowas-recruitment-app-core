using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Runtime.Session;
using EcoRecruit.Recruitment.Applicants.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Applicants
{
    public class CoverLetterManager: DomainService, ICoverLetterManager
    {

        private readonly IRepository<ApplicantCoverLetter, long> _repository;
        public IAbpSession AbpSession { get; set; }
        private readonly ILogger<CoverLetterManager> _logger; // 
        public CoverLetterManager(IRepository<ApplicantCoverLetter, long> repository, ILogger<CoverLetterManager> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<ApplicantCoverLetter> GetByIdAsync(long id)
        {
            try
            {
                return await _repository.GetAsync(id);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to create cover letter.");
                throw new ApplicationException("Failed to create cover letter.", ex);
            }

        }

        public IQueryable<ApplicantCoverLetter> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to get the list of cover letters.");
                throw new ApplicationException("Failed to get the list of cover letters.", ex);
            }

        }

        public async Task<ApplicantCoverLetter> CreateAsync(ApplicantCoverLetter value)
        {
            try
            {
                return await _repository.InsertAsync(value);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to create cover letter.");
                throw new ApplicationException("Failed to create cover letter.", ex);
            }

        }

        public async Task<ApplicantCoverLetter> UpdateAsync(ApplicantCoverLetter value)
        {

            try
            {
                return await _repository.UpdateAsync(value);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to update cover letter.");
                throw new ApplicationException("Failed to update cover letter.", ex);
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
                _logger.LogError(ex, "Failed to delete cover letter.");
                throw new ApplicationException("Failed to delete cover letter.", ex);
            }

        }


    }
}