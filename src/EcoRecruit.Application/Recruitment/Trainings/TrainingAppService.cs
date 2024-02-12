using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Localization;
using Abp.UI;
using AutoMapper;
using EcoRecruit.Application.Recruitment.Trainings.Dto;
using EcoRecruit.Recruitment.Applicants;
using EcoRecruit.Recruitment.Trainings;
using EcoRecruit.Recruitment.Trainings.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Trainings
{
    public class TrainingAppService : ApplicationService, ITrainingAppService
    {
        private readonly IRepository<ApplicantTraining, long> _sampleRepository;
        private readonly IMapper   _mapper;
        private readonly ILocalizationManager _localization;
        private readonly TrainingManager _sampleManager;

        public TrainingAppService(IRepository<ApplicantTraining, long> sampleRepository, IMapper mapper, ILocalizationManager localization, TrainingManager sampleManager)
        {
          _sampleRepository = sampleRepository;
            _mapper = mapper;
            _localization = localization;
            _sampleManager = sampleManager;
            LocalizationSourceName = "EcoRecruit";
            
        }

        public async Task<TrainingDto> GetTrainingAsync(long id)
        {
            var sample = await _sampleRepository.GetAsync(id);
            return _mapper.Map<ApplicantTraining, TrainingDto>(sample);

        }
   

        public async Task<PagedResultDto<TrainingDto>> GetTrainingsAsync(PagedTrainingResultRequestDto input)
        {

            var listOfTrainings =  _sampleManager.GetAll();
            var query = listOfTrainings;

            // Apply filtering criteria
            if (!string.IsNullOrEmpty(input.Keyword))
            {
                var searchFields = input.Keyword.Split(',');
                foreach ( var field in searchFields)
                {
                    var searchParam = field.Split(':');
                    if (searchParam.Length > 1)
                    {
                        if (searchParam[0] == "Title")
                        {
                            query = query.Where(app => app.Title.ToLower().Trim().Contains(searchParam[1].ToLower()) || searchParam[1] == "");
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
                    case "Title":
                        query = sortParam[1] == "ASC" ? query.OrderBy(a => a.Title) : query.OrderByDescending(a => a.Title);
                        break;
                   
                    default:
                        break;
                }
            }
            var Trainings = await query
                        .Skip(input.SkipCount)
                        .Take(input.MaxResultCount)
                        .ToListAsync();

            return new PagedResultDto<TrainingDto>
            {
                TotalCount = await query.CountAsync(),
                Items = _mapper.Map<List<TrainingDto>>(Trainings)
            };

        }

        public async  Task<TrainingDto> CreateAsync(CreateTrainingDto input)
        {
    
            var sample = await _sampleRepository.FirstOrDefaultAsync(app => app.Title == input.Title && app.ApplicantId == input.ApplicantId);

            if(sample != null)
            {
                throw new UserFriendlyException(L("UserFriendlyExistingTraining"));
            }
            
            sample = _mapper.Map<ApplicantTraining>(input);
            await _sampleManager.CreateAsync(sample);
            return _mapper.Map<ApplicantTraining, TrainingDto>(sample);
           
        }

        public async Task<TrainingDto> UpdateAsync(TrainingDto input)
        {
            var sample = await _sampleRepository.GetAsync(input.Id);
            if (sample == null)
            {
                throw new UserFriendlyException(L("UserFriendlyNonExistingTraining"));
            }

            sample = _mapper.Map<ApplicantTraining>(input);
            await _sampleManager.UpdateAsync(sample);
            return _mapper.Map<ApplicantTraining, TrainingDto>(sample);

        }

        public async Task DeleteAsync(long id)
        {
            await _sampleManager.DeleteAsync(id);
        }

    


    }
}
