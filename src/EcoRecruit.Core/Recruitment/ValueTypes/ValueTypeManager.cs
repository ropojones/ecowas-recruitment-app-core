using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Runtime.Session;
using EcoRecruit.Recruitment.Applicants;
using EcoRecruit.Recruitment.ValueTypes.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.ValueTypes
{
    public class ValueTypeManager : DomainService, IValueTypeManager
    {
        private readonly IRepository<ValueType, int> _repository;
        public IAbpSession AbpSession { get; set; }
        private readonly ILogger<ValueTypeManager> _logger; // 
        public ValueTypeManager(IRepository<ValueType, int> repository, ILogger<ValueTypeManager> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<ValueType> GetByIdAsync(int id)
        {
            try
            {
                return await _repository.GetAsync(id);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to create value type.");
                throw new ApplicationException("Failed to create value type.", ex);
            }

        }

        public IQueryable<ValueType> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to get the list of value types.");
                throw new ApplicationException("Failed to get the list of value types.", ex);
            }

        }

        public async Task<ValueType> CreateAsync(ValueType value)
        {
            try
            {
                return await _repository.InsertAsync(value);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to create value type.");
                throw new ApplicationException("Failed to create value type.", ex);
            }

        }

        public async Task<ValueType> UpdateAsync(ValueType value)
        {

            try
            {
                return await _repository.UpdateAsync(value);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to update value type.");
                throw new ApplicationException("Failed to update value type.", ex);
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
                _logger.LogError(ex, "Failed to delete value type.");
                throw new ApplicationException("Failed to delete value type.", ex);
            }

        }


    }
}