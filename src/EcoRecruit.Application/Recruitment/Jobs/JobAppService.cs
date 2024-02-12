using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Localization;
using Abp.UI;
using AutoMapper;
using EcoRecruit.Application.Recruitment.Jobs.Dto;
using EcoRecruit.Recruitment.Jobs.Dto;
using EcoRecruit.Recruitment.Jobs.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Jobs
{
    public class JobAppService : ApplicationService, IJobAppService
    {
        private readonly IRepository<Job, int> _jobRepository;
        private readonly IMapper   _mapper;
        private readonly ILocalizationManager _localization;
        private readonly JobManager _jobManager;

        public JobAppService(IRepository<Job, int> jobRepository, IMapper mapper, ILocalizationManager localization, JobManager jobManager)
        {
          _jobRepository = jobRepository;
            _mapper = mapper;
            _localization = localization;
            _jobManager = jobManager;
            LocalizationSourceName = "EcoRecruit";
            
        }

        public async Task<JobDto> GetJobAsync(int id)
        {
            var job = await _jobRepository.GetAsync(id);
            return _mapper.Map<Job, JobDto>(job);

        }

        public async Task<JobDto> GetJobByRefNoAsync(string jobRefNo)
        {
            var job = await _jobRepository.FirstOrDefaultAsync(jb => jb.JobRefNumber == jobRefNo);
            return _mapper.Map<Job, JobDto>(job);
        }

        public  async Task<PagedResultDto<JobDto>> GetJobsAsync(PagedJobResultRequestDto input)
        {

            var listOfJobs =  _jobManager.GetAll();
            var query = listOfJobs;

            // Apply filtering criteria
            if (!string.IsNullOrEmpty(input.Keyword))
            {
                var searchFields = input.Keyword.Split(',');
                foreach (var field in searchFields)
                {
                    var searchParam = field.Split(':');
                    if (searchParam.Length > 1)
                    {
                        if (searchParam[0] == "Title")
                        {
                            query = query.Where(app => app.Title.ToLower().Trim().Contains(searchParam[1].ToLower()) || searchParam[1] == "");
                        }
                        if (searchParam[0] == "JobRefNumber")
                        {
                            query = query.Where(app => app.JobRefNumber.ToLower().Trim().Contains(searchParam[1].ToLower()) || searchParam[1] == "");
                        }
                        if (searchParam[0] == "Type")
                        {
                            query = query.Where(app => app.Type.ToLower().Trim().Contains(searchParam[1].ToLower()) || searchParam[1] == "");
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
                    case "JobRefNumber":
                        query = sortParam[1] == "ASC" ? query.OrderBy(a => a.JobRefNumber) : query.OrderByDescending(a => a.JobRefNumber);
                        break;
                    case "Type":
                        query = sortParam[1] == "ASC" ? query.OrderBy(a => a.Type) : query.OrderByDescending(a => a.Type);
                        break;
                    default:
                        break;
                }
            }

            var jobs = await query
                        .Skip(input.SkipCount)
                        .Take(input.MaxResultCount)
                        .ToListAsync();

            return new PagedResultDto<JobDto>
            {
                TotalCount = await query.CountAsync(),
                Items = _mapper.Map<List<JobDto>>(jobs)
            };

        }

        public async  Task<JobDto> CreateAsync(CreateJobDto input)
        {
    
            var job = await _jobRepository.FirstOrDefaultAsync(app => app.Title == input.Title && app.Institution == input.Title && app.Year == input.Year);

            if(job != null)
            {
                throw new UserFriendlyException(L("UserFriendlyExistingJob"));
            }
            
            job = _mapper.Map<Job>(input);
            await _jobManager.CreateAsync(job);
            return _mapper.Map<Job, JobDto>(job);
           
        }

        public async Task<JobDto> UpdateAsync(JobDto input)
        {
            var job = await _jobRepository.GetAsync(input.Id);
            if (job == null)
            {
                throw new UserFriendlyException(L("UserFriendlyNonExistingJob"));
            }

            job = _mapper.Map<Job>(input);
            await _jobManager.UpdateAsync(job);
            return _mapper.Map<Job, JobDto>(job);

        }

        public async Task DeleteAsync(int id)
        {
            await _jobManager.DeleteAsync(id);
        }

    


    }
}
