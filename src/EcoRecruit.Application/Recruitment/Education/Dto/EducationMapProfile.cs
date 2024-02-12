using AutoMapper;
using EcoRecruit.Application.Recruitment.Educations.Dto;
using EcoRecruit.Recruitment.Applicants;

namespace EcoRecruit.Recruitment.Educations.Dto
{
    public class EducationMapProfile : Profile
    {
        public EducationMapProfile()
        {
            CreateMap<CreateEducationDto, ApplicantEducation>();
            CreateMap<EducationDto, ApplicantEducation>();
            CreateMap<ApplicantEducation, EducationDto>();
            
        }
    }
}
