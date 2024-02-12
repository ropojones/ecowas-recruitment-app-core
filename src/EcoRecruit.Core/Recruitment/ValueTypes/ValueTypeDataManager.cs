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
    public class ValueTypeDataManager: DomainService, IValueTypeDataManager
    {
        private readonly IRepository<ValueTypeData, int> _repository;
        public IAbpSession AbpSession { get; set; }
        private readonly ILogger<ValueTypeDataManager> _logger; // 
        public ValueTypeDataManager(IRepository<ValueTypeData, int> repository, ILogger<ValueTypeDataManager> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<ValueTypeData> GetByIdAsync(int id)
        {
            try
            {
                return await _repository.GetAsync(id);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to create value type data.");
                throw new ApplicationException("Failed to create value type data.", ex);
            }

        }

        public IQueryable<ValueTypeData> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to get the list of value type datas.");
                throw new ApplicationException("Failed to get the list of value type datas.", ex);
            }

        }

        public async Task<ValueTypeData> CreateAsync(ValueTypeData value)
        {
            try
            {
                return await _repository.InsertAsync(value);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to create value type data.");
                throw new ApplicationException("Failed to create value type data.", ex);
            }

        }

        public async Task<ValueTypeData> UpdateAsync(ValueTypeData value)
        {

            try
            {
                return await _repository.UpdateAsync(value);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to update value type data.");
                throw new ApplicationException("Failed to update value type data.", ex);
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
                _logger.LogError(ex, "Failed to delete value type data.");
                throw new ApplicationException("Failed to delete value type data.", ex);
            }

        }

    }
}