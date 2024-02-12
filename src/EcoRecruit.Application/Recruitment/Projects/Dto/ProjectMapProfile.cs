using AutoMapper;
using EcoRecruit.Application.Recruitment.Projects.Dto;
using EcoRecruit.Recruitment.Applicants;

namespace EcoRecruit.Recruitment.Projects.Dto
{
    public class ProjectMapProfile : Profile
    {
        public ProjectMapProfile()
        {
            CreateMap<CreateProjectDto, ApplicantProject>();
            CreateMap<ProjectDto, ApplicantProject>();
            CreateMap<ApplicantProject, ProjectDto>();
            
        }
    }
}
