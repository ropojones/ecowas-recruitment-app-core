using AutoMapper;
using EcoRecruit.Application.Recruitment.Customs.Dto;
using EcoRecruit.Recruitment.Applicants;

namespace EcoRecruit.Recruitment.Customs.Dto
{
    public class CustomMapProfile : Profile
    {
        public CustomMapProfile()
        {
            CreateMap<CreateCustomDto, ApplicantCustom>();
            CreateMap<CustomDto, ApplicantCustom>();
            CreateMap<ApplicantCustom, CustomDto>();
            
        }
    }
}
