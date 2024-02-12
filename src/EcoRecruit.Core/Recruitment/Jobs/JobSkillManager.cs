using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Runtime.Session;
using EcoRecruit.Recruitment.Applicants;
using EcoRecruit.Recruitment.Jobs.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Jobs
{
    public class JobSkillManager : DomainService, IJobSkillManager
    {

        private readonly IRepository<JobSkill, long> _repository;
        public IAbpSession AbpSession { get; set; }
        private readonly ILogger<JobSkillManager> _logger; // 
        public JobSkillManager(IRepository<JobSkill, long> repository, ILogger<JobSkillManager> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<JobSkill> GetByIdAsync(long id)
        {
            try
            {
                return await _repository.GetAsync(id);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to create job skill.");
                throw new ApplicationException("Failed to create job skill.", ex);
            }

        }

        public IQueryable<JobSkill> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to get the list of job skills.");
                throw new ApplicationException("Failed to get the list of job skills.", ex);
            }

        }

        public async Task<JobSkill> CreateAsync(JobSkill value)
        {
            try
            {
                return await _repository.InsertAsync(value);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to create job skill.");
                throw new ApplicationException("Failed to create job skill.", ex);
            }

        }

        public async Task<JobSkill> UpdateAsync(JobSkill value)
        {

            try
            {
                return await _repository.UpdateAsync(value);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to update job skill.");
                throw new ApplicationException("Failed to update job skill.", ex);
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
                _logger.LogError(ex, "Failed to delete job skill.");
                throw new ApplicationException("Failed to delete job skill.", ex);
            }

        }

    }
}