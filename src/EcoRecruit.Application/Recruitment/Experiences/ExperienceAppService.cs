using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Localization;
using Abp.UI;
using AutoMapper;
using EcoRecruit.Application.Recruitment.Experiences.Dto;
using EcoRecruit.Recruitment.Applicants;
using EcoRecruit.Recruitment.Experiences;
using EcoRecruit.Recruitment.Experiences.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Experiences
{
    public class ExperienceAppService : ApplicationService, IExperienceAppService
    {
        private readonly IRepository<ApplicantExperience, long> _experienceRepository;
        private readonly IMapper   _mapper;
        private readonly ILocalizationManager _localization;
        private readonly ExperienceManager _experienceManager;

        public ExperienceAppService(IRepository<ApplicantExperience, long> experienceRepository, IMapper mapper, ILocalizationManager localization, ExperienceManager experienceManager)
        {
          _experienceRepository = experienceRepository;
            _mapper = mapper;
            _localization = localization;
            _experienceManager = experienceManager;
            LocalizationSourceName = "EcoRecruit";
            
        }

        public async Task<ExperienceDto> GetExperienceAsync(long id)
        {
            var experience = await _experienceRepository.GetAsync(id);
            return _mapper.Map<ApplicantExperience, ExperienceDto>(experience);

        }
   

        public async Task<PagedResultDto<ExperienceDto>> GetExperiencesAsync(PagedExperienceResultRequestDto input)
        {

            var listOfExperiences =  _experienceManager.GetAll();
            var query = listOfExperiences;

            // Apply filtering criteria
            if (!string.IsNullOrEmpty(input.Keyword))
            {
                var searchFields = input.Keyword.Split(',');
                foreach ( var field in searchFields)
                {
                    var searchParam = field.Split(':');
                    if (searchParam.Length > 1)
                    {
                        if (searchParam[0] == "Organization")
                        {
                            query = query.Where(app => app.Organization.ToLower().Trim().Contains(searchParam[1].ToLower()) || searchParam[1] == "");
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
                    case "ExperienceName":
                        query = sortParam[1] == "ASC" ? query.OrderBy(a => a.Organization) : query.OrderByDescending(a => a.Organization);
                        break;
                   
                    default:
                        break;
                }
            }
            var Experiences = await query
                        .Skip(input.SkipCount)
                        .Take(input.MaxResultCount)
                        .ToListAsync();

            return new PagedResultDto<ExperienceDto>
            {
                TotalCount = await query.CountAsync(),
                Items = _mapper.Map<List<ExperienceDto>>(Experiences)
            };

        }

        public async  Task<ExperienceDto> CreateAsync(CreateExperienceDto input)
        {
    
            var experience = await _experienceRepository.FirstOrDefaultAsync(app => app.Organization == input.Organization && app.ApplicantId == input.ApplicantId);

            if(experience != null)
            {
                throw new UserFriendlyException(L("UserFriendlyExistingExperience"));
            }
            
            experience = _mapper.Map<ApplicantExperience>(input);
            await _experienceManager.CreateAsync(experience);
            return _mapper.Map<ApplicantExperience, ExperienceDto>(experience);
           
        }

        public async Task<ExperienceDto> UpdateAsync(ExperienceDto input)
        {
            var experience = await _experienceRepository.GetAsync(input.Id);
            if (experience == null)
            {
                throw new UserFriendlyException(L("UserFriendlyNonExistingExperience"));
            }

            experience = _mapper.Map<ApplicantExperience>(input);
            await _experienceManager.UpdateAsync(experience);
            return _mapper.Map<ApplicantExperience, ExperienceDto>(experience);

        }

        public async Task DeleteAsync(long id)
        {
            await _experienceManager.DeleteAsync(id);
        }

    


    }
}
