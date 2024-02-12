using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Localization;
using Abp.UI;
using AutoMapper;
using EcoRecruit.Application.Recruitment.JobLanguages.Dto;
using EcoRecruit.Recruitment.JobLanguages.Dto;
using EcoRecruit.Recruitment.Jobs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.JobLanguages
{
    public class JobLanguageAppService : ApplicationService, IJobLanguageAppService
    {
        private readonly IRepository<JobLanguage, long> _sampleRepository;
        private readonly IMapper   _mapper;
        private readonly ILocalizationManager _localization;
        private readonly JobLanguageManager _sampleManager;

        public JobLanguageAppService(IRepository<JobLanguage, long> sampleRepository, IMapper mapper, ILocalizationManager localization, JobLanguageManager sampleManager)
        {
          _sampleRepository = sampleRepository;
            _mapper = mapper;
            _localization = localization;
            _sampleManager = sampleManager;
            LocalizationSourceName = "EcoRecruit";
            
        }

        public async Task<JobLanguageDto> GetJobLanguageAsync(long id)
        {
            var sample = await _sampleRepository.GetAsync(id);
            return _mapper.Map<JobLanguage, JobLanguageDto>(sample);

        }
   

        public async Task<PagedResultDto<JobLanguageDto>> GetJobLanguagesAsync(PagedJobLanguageResultRequestDto input)
        {

            var listOfJobLanguages =  _sampleManager.GetAll();
            var query = listOfJobLanguages;

            // Apply filtering criteria
            if (!string.IsNullOrEmpty(input.Keyword))
            {
                var searchFields = input.Keyword.Split(',');
                foreach ( var field in searchFields)
                {
                    var searchParam = field.Split(':');
                    if (searchParam.Length > 1)
                    {
                        if (searchParam[0] == "Language")
                        {
                            query = query.Where(app => app.Language.ToLower().Trim().Contains(searchParam[1].ToLower()) || searchParam[1] == "");
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
                    case "Language":
                        query = sortParam[1] == "ASC" ? query.OrderBy(a => a.Language) : query.OrderByDescending(a => a.Language);
                        break;
                   
                    default:
                        break;
                }
            }
            var JobLanguages = await query
                        .Skip(input.SkipCount)
                        .Take(input.MaxResultCount)
                        .ToListAsync();

            return new PagedResultDto<JobLanguageDto>
            {
                TotalCount = await query.CountAsync(),
                Items = _mapper.Map<List<JobLanguageDto>>(JobLanguages)
            };

        }

        public async  Task<JobLanguageDto> CreateAsync(CreateJobLanguageDto input)
        {
    
            var sample = await _sampleRepository.FirstOrDefaultAsync(app => app.Language == input.Language && app.JobId == input.JobId);

            if(sample != null)
            {
                throw new UserFriendlyException(L("UserFriendlyExistingJobLanguage"));
            }
            
            sample = _mapper.Map<JobLanguage>(input);
            await _sampleManager.CreateAsync(sample);
            return _mapper.Map<JobLanguage, JobLanguageDto>(sample);
           
        }

        public async Task<JobLanguageDto> UpdateAsync(JobLanguageDto input)
        {
            var sample = await _sampleRepository.GetAsync(input.Id);
            if (sample == null)
            {
                throw new UserFriendlyException(L("UserFriendlyNonExistingJobLanguage"));
            }

            sample = _mapper.Map<JobLanguage>(input);
            await _sampleManager.UpdateAsync(sample);
            return _mapper.Map<JobLanguage, JobLanguageDto>(sample);

        }

        public async Task DeleteAsync(long id)
        {
            await _sampleManager.DeleteAsync(id);
        }

    


    }
}
