using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Localization;
using Abp.UI;
using AutoMapper;
using EcoRecruit.Application.Recruitment.Languages.Dto;
using EcoRecruit.Recruitment.Applicants;
using EcoRecruit.Recruitment.Languages.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using LanguageManager = EcoRecruit.Recruitment.Applicants.LanguageManager;

namespace EcoRecruit.Recruitment.Languages
{
    public class LanguageAppService : ApplicationService, ILanguageAppService
    {
        private readonly IRepository<ApplicantLanguage, long> _languageRepository;
        private readonly IMapper   _mapper;
        private readonly ILocalizationManager _localization;
        private readonly LanguageManager _languageManager;

        public LanguageAppService(IRepository<ApplicantLanguage, long> languageRepository, IMapper mapper, ILocalizationManager localization, LanguageManager languageManager)
        {
          _languageRepository = languageRepository;
            _mapper = mapper;
            _localization = localization;
            _languageManager = languageManager;
            LocalizationSourceName = "EcoRecruit";
            
        }

        public async Task<LanguageDto> GetLanguageAsync(long id)
        {
            var language = await _languageRepository.GetAsync(id);
            return _mapper.Map<ApplicantLanguage, LanguageDto>(language);

        }
   

        public async Task<PagedResultDto<LanguageDto>> GetLanguagesAsync(PagedLanguageResultRequestDto input)
        {

            var listOfLanguages =  _languageManager.GetAll();
            var query = listOfLanguages;

            // Apply filtering criteria
            if (!string.IsNullOrEmpty(input.Keyword))
            {
                var searchFields = input.Keyword.Split(',');
                foreach ( var field in searchFields)
                {
                    var searchParam = field.Split(':');
                    if (searchParam.Length > 1)
                    {
                        if (searchParam[0] == "LanguageString")
                        {
                            query = query.Where(app => app.LanguageString.ToLower().Trim().Contains(searchParam[1].ToLower()) || searchParam[1] == "");
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
                    case "LanguageString":
                        query = sortParam[1] == "ASC" ? query.OrderBy(a => a.LanguageString) : query.OrderByDescending(a => a.LanguageString);
                        break;
                   
                    default:
                        break;
                }
            }
            var Languages = await query
                        .Skip(input.SkipCount)
                        .Take(input.MaxResultCount)
                        .ToListAsync();

            return new PagedResultDto<LanguageDto>
            {
                TotalCount = await query.CountAsync(),
                Items = _mapper.Map<List<LanguageDto>>(Languages)
            };

        }

        public async  Task<LanguageDto> CreateAsync(CreateLanguageDto input)
        {
    
            var language = await _languageRepository.FirstOrDefaultAsync(app => app.LanguageString == input.LanguageString && app.ApplicantId == input.ApplicantId);

            if(language != null)
            {
                throw new UserFriendlyException(L("UserFriendlyExistingLanguage"));
            }
            
            language = _mapper.Map<ApplicantLanguage>(input);
            await _languageManager.CreateAsync(language);
            return _mapper.Map<ApplicantLanguage, LanguageDto>(language);
           
        }

        public async Task<LanguageDto> UpdateAsync(LanguageDto input)
        {
            var language = await _languageRepository.GetAsync(input.Id);
            if (language == null)
            {
                throw new UserFriendlyException(L("UserFriendlyNonExistingLanguage"));
            }

            language = _mapper.Map<ApplicantLanguage>(input);
            await _languageManager.UpdateAsync(language);
            return _mapper.Map<ApplicantLanguage, LanguageDto>(language);

        }

        public async Task DeleteAsync(long id)
        {
            await _languageManager.DeleteAsync(id);
        }

    


    }
}
