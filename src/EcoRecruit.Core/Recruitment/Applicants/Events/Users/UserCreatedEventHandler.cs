using Abp.Events.Bus.Entities;
using Abp.Events.Bus.Handlers;
using EcoRecruit.Authorization.Users;
using System.Threading.Tasks;
using Castle.Core.Logging;
using Abp.Domain.Repositories;
using Newtonsoft.Json.Linq;
using System;
using Abp.Logging;

namespace EcoRecruit.Recruitment.Applicants.Events.Users
{
    public class UserCreatedEventHandler : IAsyncEventHandler<EntityCreatedEventData<User>>
    {
        private readonly ILogger _logger;
       private readonly IRepository<Applicant, long> _repositoryApplicant;
       public UserCreatedEventHandler(IRepository<Applicant, long> repositoryApplicant, ILogger logger)
        {
            _repositoryApplicant = repositoryApplicant;        
            _logger = logger;
       }
        public async Task HandleEventAsync(EntityCreatedEventData<User> eventData)
        {
            var applicant = new Applicant
            {
                FirstName = eventData.Entity.Name,
                LastName = eventData.Entity.Surname,
                Email = eventData.Entity.EmailAddress,
                IsEcowas = false,
                IsEcowasVerified = false,
                UserId = eventData.Entity.Id,
            
            };

            try
            {
               await _repositoryApplicant.InsertOrUpdateAsync(applicant);
        
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.Log(LogSeverity.Info, "Failed to create applicant.");
                throw new ApplicationException("Failed to create applicant.", ex);
            }
        } 
        
    }

}
