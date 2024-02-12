using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Localization;
using Abp.UI;
using AutoMapper;
using EcoRecruit.Application.Recruitment.JobSkills.Dto;
using EcoRecruit.Recruitment.Jobs;
using EcoRecruit.Recruitment.JobSkills.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.JobSkills
{
    public class JobSkillAppService : ApplicationService, IJobSkillAppService
    {
        private readonly IRepository<JobSkill, long> _sampleRepository;
        private readonly IMapper   _mapper;
        private readonly ILocalizationManager _localization;
        private readonly JobSkillManager _sampleManager;

        public JobSkillAppService(IRepository<JobSkill, long> sampleRepository, IMapper mapper, ILocalizationManager localization, JobSkillManager sampleManager)
        {
          _sampleRepository = sampleRepository;
            _mapper = mapper;
            _localization = localization;
            _sampleManager = sampleManager;
            LocalizationSourceName = "EcoRecruit";
            
        }

        public async Task<JobSkillDto> GetJobSkillAsync(long id)
        {
            var sample = await _sampleRepository.GetAsync(id);
            return _mapper.Map<JobSkill, JobSkillDto>(sample);

        }
   

        public async Task<PagedResultDto<JobSkillDto>> GetJobSkillsAsync(PagedJobSkillResultRequestDto input)
        {

            var listOfJobSkills =  _sampleManager.GetAll();
            var query = listOfJobSkills;

            // Apply filtering criteria
            if (!string.IsNullOrEmpty(input.Keyword))
            {
                var searchFields = input.Keyword.Split(',');
                foreach ( var field in searchFields)
                {
                    var searchParam = field.Split(':');
                    if (searchParam.Length > 1)
                    {
                        if (searchParam[0] == "Skill")
                        {
                            query = query.Where(app => app.Skill.ToLower().Trim().Contains(searchParam[1].ToLower()) || searchParam[1] == "");
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
                    case "Skill":
                        query = sortParam[1] == "ASC" ? query.OrderBy(a => a.Skill) : query.OrderByDescending(a => a.Skill);
                        break;
                   
                    default:
                        break;
                }
            }
            var JobSkills = await query
                        .Skip(input.SkipCount)
                        .Take(input.MaxResultCount)
                        .ToListAsync();

            return new PagedResultDto<JobSkillDto>
            {
                TotalCount = await query.CountAsync(),
                Items = _mapper.Map<List<JobSkillDto>>(JobSkills)
            };

        }

        public async  Task<JobSkillDto> CreateAsync(CreateJobSkillDto input)
        {
    
            var sample = await _sampleRepository.FirstOrDefaultAsync(app => app.Skill == input.Skill && app.JobId == input.JobId);

            if(sample != null)
            {
                throw new UserFriendlyException(L("UserFriendlyExistingJobSkill"));
            }
            
            sample = _mapper.Map<JobSkill>(input);
            await _sampleManager.CreateAsync(sample);
            return _mapper.Map<JobSkill, JobSkillDto>(sample);
           
        }

        public async Task<JobSkillDto> UpdateAsync(JobSkillDto input)
        {
            var sample = await _sampleRepository.GetAsync(input.Id);
            if (sample == null)
            {
                throw new UserFriendlyException(L("UserFriendlyNonExistingJobSkill"));
            }

            sample = _mapper.Map<JobSkill>(input);
            await _sampleManager.UpdateAsync(sample);
            return _mapper.Map<JobSkill, JobSkillDto>(sample);

        }

        public async Task DeleteAsync(long id)
        {
            await _sampleManager.DeleteAsync(id);
        }

    


    }
}
