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
    public class SkillManager : DomainService, ISkillManager
    {
        private readonly IRepository<ApplicantSkill, long> _repository;
        public IAbpSession AbpSession { get; set; }
        private readonly ILogger<SkillManager> _logger; // 
        public SkillManager(IRepository<ApplicantSkill, long> repository, ILogger<SkillManager> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<ApplicantSkill> GetByIdAsync(long id)
        {
            try
            {
                return await _repository.GetAsync(id);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to create skill.");
                throw new ApplicationException("Failed to create skill.", ex);
            }

        }

        public IQueryable<ApplicantSkill> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to get the list of skills.");
                throw new ApplicationException("Failed to get the list of skills.", ex);
            }

        }

        public async Task<ApplicantSkill> CreateAsync(ApplicantSkill value)
        {
            try
            {
                return await _repository.InsertAsync(value);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to create skill.");
                throw new ApplicationException("Failed to create skill.", ex);
            }

        }

        public async Task<ApplicantSkill> UpdateAsync(ApplicantSkill value)
        {

            try
            {
                return await _repository.UpdateAsync(value);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to update skill.");
                throw new ApplicationException("Failed to update skill.", ex);
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
                _logger.LogError(ex, "Failed to delete skill.");
                throw new ApplicationException("Failed to delete skill.", ex);
            }

        }


    }
}