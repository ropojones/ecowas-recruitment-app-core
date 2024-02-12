using AutoMapper;
using EcoRecruit.Application.Recruitment.Experiences.Dto;
using EcoRecruit.Recruitment.Applicants;

namespace EcoRecruit.Recruitment.Experiences.Dto
{
    public class ExperienceMapProfile : Profile
    {
        public ExperienceMapProfile()
        {
            CreateMap<CreateExperienceDto, ApplicantExperience>();
            CreateMap<ExperienceDto, ApplicantExperience>();
            CreateMap<ApplicantExperience, ExperienceDto>();
            
        }
    }
}
