using Abp.Domain.Repositories;
using Abp.Domain.Services;
using EcoRecruit.Recruitment.Applicants.Interfaces;
using EcoRecruit.Recruitment.Applicants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcoRecruit.Authorization.Users;
using Abp.Runtime.Session;
using EcoRecruit.MultiTenancy;
using Microsoft.AspNetCore.Identity;
using EcoRecruit.Authorization.Roles;
using Abp.Authorization.Users;
using Microsoft.EntityFrameworkCore;
using Abp.IdentityFramework;
using Abp.UI;
using Microsoft.Extensions.Logging;
using System.Collections;
using Newtonsoft.Json.Linq;
using Abp.EntityFrameworkCore.Extensions;

namespace EcoRecruit.Recruitment.Applicants
{
    public class ApplicantManager: DomainService, IApplicantManager
    {
        private readonly IRepository<Applicant, long> _repository;
       
        public IAbpSession AbpSession { get; set; }
        private readonly ILogger<ApplicantManager> _logger; // 

        public ApplicantManager(IRepository<Applicant, long> repository, ILogger<ApplicantManager> logger)
                                {
                                    _logger = logger;
                                    _repository = repository;                                    
                                }

        public async Task<Applicant> GetByIdAsync(long id)
        {
            try 
            {
                var applicant=  await _repository.GetAsync(id);
                if (applicant == null)
                {
                    return null;
                }
                else
                {
                       return applicant;
                }
            }
            catch (Exception ex) {
                // Log the exception
                _logger.LogError(ex, "Failed to create applicant.");
                throw new ApplicationException("Failed to create applicant.", ex);                
            }
          
        }
        public async Task<Applicant> GetByUserIdAsync(long userId)
        {
            try
            {
                var applicant= await _repository.SingleAsync(app => app.UserId == userId)
                    ;
                if (applicant != null)
                {
                    return applicant;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to create applicant.");
                throw new ApplicationException("Failed to create applicant.", ex);
            }

        }

        public  IQueryable<Applicant> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to get the list of applicants.");
                throw new ApplicationException("Failed to get the list of applicants.", ex);
            }
        
        }

        public async Task<Applicant> CreateAsync(Applicant value)
        {
            try
            {
                return await _repository.InsertAsync(value);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to create applicant.");
                throw new ApplicationException("Failed to create applicant.", ex);
            }
            
        }

        public async Task<Applicant> UpdateAsync(Applicant value)
        {
      
            try
            {
                return await _repository.UpdateAsync(value);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to update applicant.");
                throw new ApplicationException("Failed to update applicant.", ex);
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
                _logger.LogError(ex, "Failed to delete applicant.");
                throw new ApplicationException("Failed to delete applicant.", ex);
            }
          
        }

         
       public async Task<bool> IsCreated(long userId)
        {
            var applicant = await _repository.GetAll().FirstOrDefaultAsync(app => app.UserId == userId);
            return applicant != null;
            

        }
    }
}