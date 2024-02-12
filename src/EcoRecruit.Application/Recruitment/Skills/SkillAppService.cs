using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Localization;
using Abp.UI;
using AutoMapper;
using EcoRecruit.Application.Recruitment.Skills.Dto;
using EcoRecruit.Recruitment.Applicants;
using EcoRecruit.Recruitment.Skills.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Skills
{
    public class SkillAppService : ApplicationService, ISkillAppService
    {
        private readonly IRepository<ApplicantSkill, long> _sampleRepository;
        private readonly IMapper   _mapper;
        private readonly ILocalizationManager _localization;
        private readonly SkillManager _sampleManager;

        public SkillAppService(IRepository<ApplicantSkill, long> sampleRepository, IMapper mapper, ILocalizationManager localization, SkillManager sampleManager)
        {
          _sampleRepository = sampleRepository;
            _mapper = mapper;
            _localization = localization;
            _sampleManager = sampleManager;
            LocalizationSourceName = "EcoRecruit";
            
        }

        public async Task<SkillDto> GetSkillAsync(long id)
        {
            var sample = await _sampleRepository.GetAsync(id);
            return _mapper.Map<ApplicantSkill, SkillDto>(sample);

        }
   

        public async Task<PagedResultDto<SkillDto>> GetSkillsAsync(PagedSkillResultRequestDto input)
        {

            var listOfSkills =  _sampleManager.GetAll();
            var query = listOfSkills;

            // Apply filtering criteria
            if (!string.IsNullOrEmpty(input.Keyword))
            {
                var searchFields = input.Keyword.Split(',');
                foreach ( var field in searchFields)
                {
                    var searchParam = field.Split(':');
                    if (searchParam.Length > 1)
                    {
                        if (searchParam[0] == "SkillString")
                        {
                            query = query.Where(app => app.SkillString.ToLower().Trim().Contains(searchParam[1].ToLower()) || searchParam[1] == "");
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
                    case "SkillString":
                        query = sortParam[1] == "ASC" ? query.OrderBy(a => a.SkillString) : query.OrderByDescending(a => a.SkillString);
                        break;
                   
                    default:
                        break;
                }
            }
            var Skills = await query
                        .Skip(input.SkipCount)
                        .Take(input.MaxResultCount)
                        .ToListAsync();

            return new PagedResultDto<SkillDto>
            {
                TotalCount = await query.CountAsync(),
                Items = _mapper.Map<List<SkillDto>>(Skills)
            };

        }

        public async  Task<SkillDto> CreateAsync(CreateSkillDto input)
        {
    
            var sample = await _sampleRepository.FirstOrDefaultAsync(app => app.SkillString == input.SkillString && app.ApplicantId == input.ApplicantId);

            if(sample != null)
            {
                throw new UserFriendlyException(L("UserFriendlyExistingSkill"));
            }
            
            sample = _mapper.Map<ApplicantSkill>(input);
            await _sampleManager.CreateAsync(sample);
            return _mapper.Map<ApplicantSkill, SkillDto>(sample);
           
        }

        public async Task<SkillDto> UpdateAsync(SkillDto input)
        {
            var sample = await _sampleRepository.GetAsync(input.Id);
            if (sample == null)
            {
                throw new UserFriendlyException(L("UserFriendlyNonExistingSkill"));
            }

            sample = _mapper.Map<ApplicantSkill>(input);
            await _sampleManager.UpdateAsync(sample);
            return _mapper.Map<ApplicantSkill, SkillDto>(sample);

        }

        public async Task DeleteAsync(long id)
        {
            await _sampleManager.DeleteAsync(id);
        }

    


    }
}
