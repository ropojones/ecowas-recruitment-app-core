using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Localization;
using Abp.UI;
using AutoMapper;
using EcoRecruit.Application.Recruitment.JobEcowasCompetences.Dto;
using EcoRecruit.Recruitment.JobEcowasCompetences.Dto;
using EcoRecruit.Recruitment.Jobs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.JobEcowasCompetences
{
    public class JobEcowasCompetenceAppService : ApplicationService, IJobEcowasCompetenceAppService
    {
        private readonly IRepository<JobEcowasCompetence, long> _sampleRepository;
        private readonly IMapper   _mapper;
        private readonly ILocalizationManager _localization;
        private readonly JobEcowasCompetenceManager _sampleManager;

        public JobEcowasCompetenceAppService(IRepository<JobEcowasCompetence, long> sampleRepository, IMapper mapper, ILocalizationManager localization, JobEcowasCompetenceManager sampleManager)
        {
          _sampleRepository = sampleRepository;
            _mapper = mapper;
            _localization = localization;
            _sampleManager = sampleManager;
            LocalizationSourceName = "EcoRecruit";
            
        }

        public async Task<JobEcowasCompetenceDto> GetJobEcowasCompetenceAsync(long id)
        {
            var sample = await _sampleRepository.GetAsync(id);
            return _mapper.Map<JobEcowasCompetence, JobEcowasCompetenceDto>(sample);

        }
   

        public async Task<PagedResultDto<JobEcowasCompetenceDto>> GetJobEcowasCompetencesAsync(PagedJobEcowasCompetenceResultRequestDto input)
        {

            var listOfJobEcowasCompetences =  _sampleManager.GetAll();
            var query = listOfJobEcowasCompetences;

            // Apply filtering criteria
            if (!string.IsNullOrEmpty(input.Keyword))
            {
                var searchFields = input.Keyword.Split(',');
                foreach ( var field in searchFields)
                {
                    var searchParam = field.Split(':');
                    if (searchParam.Length > 1)
                    {
                        if (searchParam[0] == "Competence")
                        {
                            query = query.Where(app => app.Competence.ToLower().Trim().Contains(searchParam[1].ToLower()) || searchParam[1] == "");
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
                    case "Competence":
                        query = sortParam[1] == "ASC" ? query.OrderBy(a => a.Competence) : query.OrderByDescending(a => a.Competence);
                        break;
                   
                    default:
                        break;
                }
            }
            var JobEcowasCompetences = await query
                        .Skip(input.SkipCount)
                        .Take(input.MaxResultCount)
                        .ToListAsync();

            return new PagedResultDto<JobEcowasCompetenceDto>
            {
                TotalCount = await query.CountAsync(),
                Items = _mapper.Map<List<JobEcowasCompetenceDto>>(JobEcowasCompetences)
            };

        }

        public async  Task<JobEcowasCompetenceDto> CreateAsync(CreateJobEcowasCompetenceDto input)
        {
    
            var sample = await _sampleRepository.FirstOrDefaultAsync(app => app.Competence == input.Competence);

            if(sample != null)
            {
                throw new UserFriendlyException(L("UserFriendlyExistingJobEcowasCompetence"));
            }
            
            sample = _mapper.Map<JobEcowasCompetence>(input);
            await _sampleManager.CreateAsync(sample);
            return _mapper.Map<JobEcowasCompetence, JobEcowasCompetenceDto>(sample);
           
        }

        public async Task<JobEcowasCompetenceDto> UpdateAsync(JobEcowasCompetenceDto input)
        {
            var sample = await _sampleRepository.GetAsync(input.Id);
            if (sample == null)
            {
                throw new UserFriendlyException(L("UserFriendlyNonExistingJobEcowasCompetence"));
            }

            sample = _mapper.Map<JobEcowasCompetence>(input);
            await _sampleManager.UpdateAsync(sample);
            return _mapper.Map<JobEcowasCompetence, JobEcowasCompetenceDto>(sample);

        }

        public async Task DeleteAsync(long id)
        {
            await _sampleManager.DeleteAsync(id);
        }

    


    }
}
