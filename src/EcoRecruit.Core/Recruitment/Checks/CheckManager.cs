using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Runtime.Session;
using EcoRecruit.Recruitment.Applicants;
using EcoRecruit.Recruitment.Checks.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Checks
{
    public class CheckManager : DomainService, ICheckManager
    {
        private readonly IRepository<Check, int> _repository;
        public IAbpSession AbpSession { get; set; }
        private readonly ILogger<CheckManager> _logger; // 

        public CheckManager(IRepository<Check, int> repository, ILogger<CheckManager> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Check> GetByIdAsync(int id)
        {
            try
            {
                return await _repository.GetAsync(id);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to create check.");
                throw new ApplicationException("Failed to create check.", ex);
            }

        }

        public IQueryable<Check> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to get the list of checks.");
                throw new ApplicationException("Failed to get the list of checks.", ex);
            }

        }

        public async Task<Check> CreateAsync(Check value)
        {
            try
            {
                return await _repository.InsertAsync(value);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to create check.");
                throw new ApplicationException("Failed to create check.", ex);
            }

        }

        public async Task<Check> UpdateAsync(Check value)
        {

            try
            {
                return await _repository.UpdateAsync(value);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to update check.");
                throw new ApplicationException("Failed to update check.", ex);
            }

        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                await _repository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to delete check.");
                throw new ApplicationException("Failed to delete check.", ex);
            }

        }


    }
}