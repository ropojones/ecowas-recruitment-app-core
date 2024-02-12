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
    public class ProjectManager : DomainService, IProjectManager
    {
        private readonly IRepository<ApplicantProject, long> _repository;
        public IAbpSession AbpSession { get; set; }
        private readonly ILogger<ProjectManager> _logger; // 
        public ProjectManager(IRepository<ApplicantProject, long> repository, ILogger<ProjectManager> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<ApplicantProject> GetByIdAsync(long id)
        {
            try
            {
                return await _repository.GetAsync(id);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to create project.");
                throw new ApplicationException("Failed to create project.", ex);
            }

        }

        public IQueryable<ApplicantProject> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to get the list of projects.");
                throw new ApplicationException("Failed to get the list of projects.", ex);
            }

        }

        public async Task<ApplicantProject> CreateAsync(ApplicantProject value)
        {
            try
            {
                return await _repository.InsertAsync(value);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to create project.");
                throw new ApplicationException("Failed to create project.", ex);
            }

        }

        public async Task<ApplicantProject> UpdateAsync(ApplicantProject value)
        {

            try
            {
                return await _repository.UpdateAsync(value);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to update project.");
                throw new ApplicationException("Failed to update project.", ex);
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
                _logger.LogError(ex, "Failed to delete project.");
                throw new ApplicationException("Failed to delete project.", ex);
            }

        }

    }
}