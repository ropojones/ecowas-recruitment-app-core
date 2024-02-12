using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Runtime.Session;
using EcoRecruit.Recruitment.Applicants;
using EcoRecruit.Recruitment.Countries.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Countries
{
    public class CountryManager: DomainService,ICountryManager
    {
        private readonly IRepository<Country, int> _repository;
        public IAbpSession AbpSession { get; set; }
        private readonly ILogger<CountryManager> _logger; // 
        public CountryManager(IRepository<Country, int> repository, ILogger<CountryManager> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Country> GetByIdAsync(int id)
        {
            try
            {
                return await _repository.GetAsync(id);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to create country.");
                throw new ApplicationException("Failed to create country.", ex);
            }

        }

        public IQueryable<Country> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to get the list of countrys.");
                throw new ApplicationException("Failed to get the list of countrys.", ex);
            }

        }

        public async Task<Country> CreateAsync(Country value)
        {
            try
            {
                return await _repository.InsertAsync(value);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to create country.");
                throw new ApplicationException("Failed to create country.", ex);
            }

        }

        public async Task<Country> UpdateAsync(Country value)
        {

            try
            {
                return await _repository.UpdateAsync(value);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to update country.");
                throw new ApplicationException("Failed to update country.", ex);
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
                _logger.LogError(ex, "Failed to delete country.");
                throw new ApplicationException("Failed to delete country.", ex);
            }

        }


    }
}