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
    public class TrainingManager : DomainService, ITrainingManager
    {
        private readonly IRepository<ApplicantTraining, long> _repository;
        public IAbpSession AbpSession { get; set; }
        private readonly ILogger<TrainingManager> _logger; // 
        public TrainingManager(IRepository<ApplicantTraining, long> repository, ILogger<TrainingManager> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<ApplicantTraining> GetByIdAsync(long id)
        {
            try
            {
                return await _repository.GetAsync(id);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to create training.");
                throw new ApplicationException("Failed to create training.", ex);
            }

        }

        public IQueryable<ApplicantTraining> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to get the list of trainings.");
                throw new ApplicationException("Failed to get the list of trainings.", ex);
            }

        }

        public async Task<ApplicantTraining> CreateAsync(ApplicantTraining value)
        {
            try
            {
                return await _repository.InsertAsync(value);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to create training.");
                throw new ApplicationException("Failed to create training.", ex);
            }

        }

        public async Task<ApplicantTraining> UpdateAsync(ApplicantTraining value)
        {

            try
            {
                return await _repository.UpdateAsync(value);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to update training.");
                throw new ApplicationException("Failed to update training.", ex);
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
                _logger.LogError(ex, "Failed to delete training.");
                throw new ApplicationException("Failed to delete training.", ex);
            }

        }

    }
}