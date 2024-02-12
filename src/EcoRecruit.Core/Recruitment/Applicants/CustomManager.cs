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
    public class CustomManager: DomainService, ICustomManager
    {

        private readonly IRepository<ApplicantCustom, long> _repository;
        public IAbpSession AbpSession { get; set; }
        private readonly ILogger<CustomManager> _logger; // 
        public CustomManager(IRepository<ApplicantCustom, long> repository, ILogger<CustomManager> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<ApplicantCustom> GetByIdAsync(long id)
        {
            try
            {
                return await _repository.GetAsync(id);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to create custom.");
                throw new ApplicationException("Failed to create custom.", ex);
            }

        }

        public IQueryable<ApplicantCustom> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to get the list of customs.");
                throw new ApplicationException("Failed to get the list of customs.", ex);
            }

        }

        public async Task<ApplicantCustom> CreateAsync(ApplicantCustom value)
        {
            try
            {
                return await _repository.InsertAsync(value);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to create custom.");
                throw new ApplicationException("Failed to create custom.", ex);
            }

        }

        public async Task<ApplicantCustom> UpdateAsync(ApplicantCustom value)
        {

            try
            {
                return await _repository.UpdateAsync(value);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to update custom.");
                throw new ApplicationException("Failed to update custom.", ex);
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
                _logger.LogError(ex, "Failed to delete custom.");
                throw new ApplicationException("Failed to delete custom.", ex);
            }

        }

    }
}