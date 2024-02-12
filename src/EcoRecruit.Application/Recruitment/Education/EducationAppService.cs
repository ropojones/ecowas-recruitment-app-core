using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Localization;
using Abp.UI;
using AutoMapper;
using EcoRecruit.Application.Recruitment.Educations.Dto;
using EcoRecruit.Recruitment.Applicants;
using EcoRecruit.Recruitment.Educations;
using EcoRecruit.Recruitment.Educations.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Educations
{
    public class EducationAppService : ApplicationService, IEducationAppService
    {
        private readonly IRepository<ApplicantEducation, long> _educationRepository;
        private readonly IMapper   _mapper;
        private readonly ILocalizationManager _localization;
        private readonly EducationManager _educationManager;

        public EducationAppService(IRepository<ApplicantEducation, long> educationRepository, IMapper mapper, ILocalizationManager localization, EducationManager educationManager)
        {
          _educationRepository = educationRepository;
            _mapper = mapper;
            _localization = localization;
            _educationManager = educationManager;
            LocalizationSourceName = "EcoRecruit";
            
        }

        public async Task<EducationDto> GetEducationAsync(long id)
        {
            var education = await _educationRepository.GetAsync(id);
            return _mapper.Map<ApplicantEducation, EducationDto>(education);

        }
   

        public async Task<PagedResultDto<EducationDto>> GetEducationsAsync(PagedEducationResultRequestDto input)
        {

            var listOfEducations =  _educationManager.GetAll();
            var query = listOfEducations;

            // Apply filtering criteria
            if (!string.IsNullOrEmpty(input.Keyword))
            {
                var searchFields = input.Keyword.Split(',');
                foreach ( var field in searchFields)
                {
                    var searchParam = field.Split(':');
                    if (searchParam.Length > 1)
                    {
                        if (searchParam[0] == "Institution")
                        {
                            query = query.Where(app => app.Institution.ToLower().Trim().Contains(searchParam[1].ToLower()) || searchParam[1] == "");
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
                    case "Institution":
                        query = sortParam[1] == "ASC" ? query.OrderBy(a => a.Institution) : query.OrderByDescending(a => a.Institution);
                        break;
                   
                    default:
                        break;
                }
            }
            var Educations = await query
                        .Skip(input.SkipCount)
                        .Take(input.MaxResultCount)
                        .ToListAsync();

            return new PagedResultDto<EducationDto>
            {
                TotalCount = await query.CountAsync(),
                Items = _mapper.Map<List<EducationDto>>(Educations)
            };

        }

        public async  Task<EducationDto> CreateAsync(CreateEducationDto input)
        {
    
            var education = await _educationRepository.FirstOrDefaultAsync(app => app.Institution == input.Institution && app.ApplicantId == input.ApplicantId);

            if(education != null)
            {
                throw new UserFriendlyException(L("UserFriendlyExistingEducation"));
            }
            
            education = _mapper.Map<ApplicantEducation>(input);
            await _educationManager.CreateAsync(education);
            return _mapper.Map<ApplicantEducation, EducationDto>(education);
           
        }

        public async Task<EducationDto> UpdateAsync(EducationDto input)
        {
            var education = await _educationRepository.GetAsync(input.Id);
            if (education == null)
            {
                throw new UserFriendlyException(L("UserFriendlyNonExistingEducation"));
            }

            education = _mapper.Map<ApplicantEducation>(input);
            await _educationManager.UpdateAsync(education);
            return _mapper.Map<ApplicantEducation, EducationDto>(education);

        }

        public async Task DeleteAsync(long id)
        {
            await _educationManager.DeleteAsync(id);
        }

    


    }
}
