using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Localization;
using Abp.UI;
using AutoMapper;
using EcoRecruit.Application.Recruitment.JobSpecialRequirements.Dto;
using EcoRecruit.Recruitment.Jobs;
using EcoRecruit.Recruitment.JobSpecialRequirements;
using EcoRecruit.Recruitment.JobSpecialRequirements.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.JobSpecialRequirements
{
    public class JobSpecialRequirementAppService : ApplicationService, IJobSpecialRequirementAppService
    {
        private readonly IRepository<JobSpecialRequirement, long> _sampleRepository;
        private readonly IMapper   _mapper;
        private readonly ILocalizationManager _localization;
        private readonly JobSpecialRequirementManager _sampleManager;

        public JobSpecialRequirementAppService(IRepository<JobSpecialRequirement, long> sampleRepository, IMapper mapper, ILocalizationManager localization, JobSpecialRequirementManager sampleManager)
        {
          _sampleRepository = sampleRepository;
            _mapper = mapper;
            _localization = localization;
            _sampleManager = sampleManager;
            LocalizationSourceName = "EcoRecruit";
            
        }

        public async Task<Application.Recruitment.JobSpecialRequirements.Dto.JobSpecialRequirementDto> GetJobSpecialRequirementAsync(long id)
        {
            var sample = await _sampleRepository.GetAsync(id);
            return _mapper.Map<JobSpecialRequirement, JobSpecialRequirementDto>(sample);

        }
   

        public async Task<PagedResultDto<JobSpecialRequirementDto>> GetJobSpecialRequirementsAsync(PagedJobSpecialRequirementResultRequestDto input)
        {

            var listOfJobSpecialRequirements =  _sampleManager.GetAll();
            var query = listOfJobSpecialRequirements;

            // Apply filtering criteria
            if (!string.IsNullOrEmpty(input.Keyword))
            {
                var searchFields = input.Keyword.Split(',');
                foreach ( var field in searchFields)
                {
                    var searchParam = field.Split(':');
                    if (searchParam.Length > 1)
                    {
                        if (searchParam[0] == "Requirement")
                        {
                            query = query.Where(app => app.Requirement.ToLower().Trim().Contains(searchParam[1].ToLower()) || searchParam[1] == "");
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
                    case "Requirement":
                        query = sortParam[1] == "ASC" ? query.OrderBy(a => a.Requirement) : query.OrderByDescending(a => a.Requirement);
                        break;
                   
                    default:
                        break;
                }
            }
            var JobSpecialRequirements = await query
                        .Skip(input.SkipCount)
                        .Take(input.MaxResultCount)
                        .ToListAsync();

            return new PagedResultDto<JobSpecialRequirementDto>
            {
                TotalCount = await query.CountAsync(),
                Items = _mapper.Map<List<JobSpecialRequirementDto>>(JobSpecialRequirements)
            };

        }

        public async  Task<JobSpecialRequirementDto> CreateAsync(CreateJobSpecialRequirementDto input)
        {
    
            var sample = await _sampleRepository.FirstOrDefaultAsync(app => app.Requirement == input.Requirement  && app.JobId == input.JobId && app.CheckId == input.CheckId);

            if(sample != null)
            {
                throw new UserFriendlyException(L("UserFriendlyExistingJobSpecialRequirement"));
            }
            
            sample = _mapper.Map<JobSpecialRequirement>(input);
            await _sampleManager.CreateAsync(sample);
            return _mapper.Map<JobSpecialRequirement, JobSpecialRequirementDto>(sample);
           
        }

        public async Task<JobSpecialRequirementDto> UpdateAsync(JobSpecialRequirementDto input)
        {
            var sample = await _sampleRepository.GetAsync(input.Id);
            if (sample == null)
            {
                throw new UserFriendlyException(L("UserFriendlyNonExistingJobSpecialRequirement"));
            }

            sample = _mapper.Map<JobSpecialRequirement>(input);
            await _sampleManager.UpdateAsync(sample);
            return _mapper.Map<JobSpecialRequirement, JobSpecialRequirementDto>(sample);

        }

        public async Task DeleteAsync(long id)
        {
            await _sampleManager.DeleteAsync(id);
        }

    


    }
}
