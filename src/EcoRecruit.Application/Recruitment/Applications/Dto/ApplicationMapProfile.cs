using AutoMapper;
using EcoRecruit.Recruitment.Applications.Dto;

namespace EcoRecruit.Recruitment.Applications.Dto
{
    public class ApplicationMapProfile : Profile
    {
        public ApplicationMapProfile()
        {
            CreateMap<CreateApplicationDto, Application>();
            CreateMap<ApplicationDto, Application>();
            CreateMap<Application, ApplicationDto>();
            
        }
    }
}
