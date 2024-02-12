using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Localization;
using Abp.UI;
using AutoMapper;
using EcoRecruit.Application.Recruitment.Projects.Dto;
using EcoRecruit.Recruitment.Applicants;
using EcoRecruit.Recruitment.Projects;
using EcoRecruit.Recruitment.Projects.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Projects
{
    public class ProjectAppService : ApplicationService, IProjectAppService
    {
        private readonly IRepository<ApplicantProject, long> _projectRepository;
        private readonly IMapper   _mapper;
        private readonly ILocalizationManager _localization;
        private readonly ProjectManager _projectManager;

        public ProjectAppService(IRepository<ApplicantProject, long> projectRepository, IMapper mapper, ILocalizationManager localization, ProjectManager projectManager)
        {
          _projectRepository = projectRepository;
            _mapper = mapper;
            _localization = localization;
            _projectManager = projectManager;
            LocalizationSourceName = "EcoRecruit";
            
        }

        public async Task<ProjectDto> GetProjectAsync(long id)
        {
            var project = await _projectRepository.GetAsync(id);
            return _mapper.Map<ApplicantProject, ProjectDto>(project);

        }
   

        public async Task<PagedResultDto<ProjectDto>> GetProjectsAsync(PagedProjectResultRequestDto input)
        {

            var listOfProjects =  _projectManager.GetAll();
            var query = listOfProjects;

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
            var Projects = await query
                        .Skip(input.SkipCount)
                        .Take(input.MaxResultCount)
                        .ToListAsync();

            return new PagedResultDto<ProjectDto>
            {
                TotalCount = await query.CountAsync(),
                Items = _mapper.Map<List<ProjectDto>>(Projects)
            };

        }

        public async  Task<ProjectDto> CreateAsync(CreateProjectDto input)
        {
    
            var project = await _projectRepository.FirstOrDefaultAsync(app => app.Title == input.Title && app.ApplicantId == input.ApplicantId);

            if(project != null)
            {
                throw new UserFriendlyException(L("UserFriendlyExistingProject"));
            }
            
            project = _mapper.Map<ApplicantProject>(input);
            await _projectManager.CreateAsync(project);
            return _mapper.Map<ApplicantProject, ProjectDto>(project);
           
        }

        public async Task<ProjectDto> UpdateAsync(ProjectDto input)
        {
            var project = await _projectRepository.GetAsync(input.Id);
            if (project == null)
            {
                throw new UserFriendlyException(L("UserFriendlyNonExistingProject"));
            }

            project = _mapper.Map<ApplicantProject>(input);
            await _projectManager.UpdateAsync(project);
            return _mapper.Map<ApplicantProject, ProjectDto>(project);

        }

        public async Task DeleteAsync(long id)
        {
            await _projectManager.DeleteAsync(id);
        }

    


    }
}
