using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.Localization;
using Abp.ObjectMapping;
using Abp.UI;
using AutoMapper;
using AutoMapper.Internal.Mappers;
using EcoRecruit.Application.Recruitment.Projects.Dto;
using EcoRecruit.Authorization;
using EcoRecruit.Authorization.Users;
using EcoRecruit.Recruitment.Applicants.Dto;
using EcoRecruit.Recruitment.Applications.Dto;
using EcoRecruit.Users.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Applications
{
    
    public class ApplicationAppService : ApplicationService, IApplicationAppService
    {
        private readonly IRepository<Application, long> _applicationRepository;
        private readonly IMapper   _mapper;
        private readonly ILocalizationManager _localization;
        private readonly ApplicationManager _applicationManager;

        public ApplicationAppService(IRepository<Application, long> applicationRepository, IMapper mapper, ILocalizationManager localization, ApplicationManager applicationManager)
        {
          _applicationRepository = applicationRepository;
            _mapper = mapper;
            _localization = localization;
            _applicationManager = applicationManager;
            LocalizationSourceName = "EcoRecruit";
            
        }

        public async Task<ApplicationDto> GetApplicationAsync(long id)
        {
            var application = await _applicationRepository.GetAsync(id);

            return _mapper.Map<Application, ApplicationDto>(application);

        }

        public async Task<PagedResultDto<ApplicationDto>> GetApplicationsAsync(PagedApplicationResultRequestDto input)
        {

            var listOfApplications =  _applicationManager.GetAll();

            var query = listOfApplications;

            // Apply filtering criteria
            if (!string.IsNullOrEmpty(input.Keyword))
            {
                var searchFields = input.Keyword.Split(',');
                foreach ( var field in searchFields)
                {
                    var searchParam = field.Split(':');
                    if (searchParam.Length > 1)
                    {
                        if (searchParam[0] == "JobRefNumber" && searchParam[1] != "")
                        {
                            query = query.Where(appc => appc.JobId == int.Parse(searchParam[1]));
                        }                    
                        if (searchParam[0] == "ApplicationNumber" && searchParam[1] != "")
                        {
                            query = query.Where(appc => appc.ApplicationNumber == searchParam[1]);
                        }
                        if (searchParam[0] == "ApplicantNumber" && searchParam[1] != "")
                        {
                            query = query.Where(appc => appc.ApplicantNumber == searchParam[1]);
                        }
                        if (searchParam[0] == "Gender" && searchParam[1] != "")
                        {
                            query = query.Where(appc => appc.Gender == searchParam[1]);
                        }
                        if (searchParam[0] == "Country" && searchParam[1] != "")
                        {
                            query = query.Where(appc => appc.Country == searchParam[1]);
                        }
                        if (searchParam[0] == "HasEcowasHistory" && searchParam[1] != "")
                        {
                            query = query.Where(appc => appc.HasEcowasHistory == true);
                        }

                    }
                }      
              
            }
            //// Apply sorting criteria
            if (!string.IsNullOrEmpty(input.Sorting))
            {
                var sortParam = input.Sorting.Split(':');
                switch (sortParam[0])
                {
                   case "JobRefNumber":
                        query = sortParam[1] == "ASC" ? query.OrderBy(appc => appc.JobRefNumber) : query.OrderByDescending(a => a.JobRefNumber);
                        break;
                    case "ApplicantNumber":
                        query = sortParam[1] == "ASC" ? query.OrderBy(a => a.ApplicantNumber) : query.OrderByDescending(a => a.ApplicantNumber);
                        break;
                    case "ApplicationNumber":
                        query = sortParam[1] == "ASC" ? query.OrderBy(a => a.ApplicationNumber) : query.OrderByDescending(a => a.ApplicationNumber);
                        break;
                    case "Country":
                        query = sortParam[1] == "ASC" ? query.OrderBy(a => a.Country) : query.OrderByDescending(a => a.Country);
                        break;
                    case "Gender":
                        query = sortParam[1] == "ASC" ? query.OrderBy(a => a.Gender) : query.OrderByDescending(a => a.Gender);
                        break;
                    default:
                        break;
                }
            }
            var applications = await query
                        .Skip(input.SkipCount)
                        .Take(input.MaxResultCount)
                        .ToListAsync();

            return new PagedResultDto<ApplicationDto>
            {
                TotalCount = await query.CountAsync(),
                Items = _mapper.Map<List<ApplicationDto>>(applications)
            };

        }

        public async  Task<ApplicationDto> CreateAsync(CreateApplicationDto input)
        {
    
           var application = await _applicationRepository.FirstOrDefaultAsync(appc => appc.JobId == input.JobId && appc.ApplicantId == input.ApplicantId);

            if(application != null)
            {
                throw new UserFriendlyException(L("UserFriendlyExistingApplication"));
            }
            
            application = _mapper.Map<Application>(input);
            await _applicationManager.CreateAsync(application);
            return _mapper.Map<Application, ApplicationDto>(application);
           
        }

        public async Task<ApplicationDto> UpdateAsync(ApplicationDto input)
        {
            var application = await _applicationRepository.GetAsync(input.Id);
            if (application == null)
            {
                throw new UserFriendlyException(L("UserFriendlyNonExistingApplication"));
            }

            application = _mapper.Map<Application>(input);
            await _applicationManager.UpdateAsync(application);
            return _mapper.Map<Application, ApplicationDto>(application);

        }

        public async Task DeleteAsync(long id)
        {
            await _applicationManager.DeleteAsync(id);
        }

       
    }
}
