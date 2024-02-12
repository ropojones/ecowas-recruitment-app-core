using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Runtime.Session;
using EcoRecruit.Recruitment.Applicants;
using EcoRecruit.Recruitment.Applicants.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.CertificateAwardeds
{
    public class CertificateAwardedManager: DomainService, ICertificateAwardedManager
    {
    

        private readonly IRepository<ApplicantCertificateAwarded, long> _repository;
        public IAbpSession AbpSession { get; set; }
        private readonly ILogger<CertificateAwardedManager> _logger; // 
        public CertificateAwardedManager(IRepository<ApplicantCertificateAwarded, long> repository, ILogger<CertificateAwardedManager> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<ApplicantCertificateAwarded> GetByIdAsync(long id)
        {
            try 
            {
                return await _repository.GetAsync(id);
            }
            catch (Exception ex) {
                // Log the exception
                _logger.LogError(ex, "Failed to create certificate awarded.");
                throw new ApplicationException("Failed to create certificate awarded.", ex);                
            }
          
        }

        public  IQueryable<ApplicantCertificateAwarded> GetAll()
        {
            try
            {
                return  _repository.GetAll();
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to get the list of certificate awardeds.");
                throw new ApplicationException("Failed to get the list of certificate awardeds.", ex);
            }
        
        }

        public async Task<ApplicantCertificateAwarded> CreateAsync(ApplicantCertificateAwarded value)
        {
            try
            {
                return await _repository.InsertAsync(value);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to create certificate awarded.");
                throw new ApplicationException("Failed to create certificate awarded.", ex);
            }
            
        }

        public async Task<ApplicantCertificateAwarded> UpdateAsync(ApplicantCertificateAwarded value)
        {
      
            try
            {
                return await _repository.UpdateAsync(value);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Failed to update certificate awarded.");
                throw new ApplicationException("Failed to update certificate awarded.", ex);
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
                _logger.LogError(ex, "Failed to delete certificate awarded.");
                throw new ApplicationException("Failed to delete certificate awarded.", ex);
            }
          
        }



    }
}