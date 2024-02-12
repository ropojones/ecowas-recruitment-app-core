using AutoMapper;
using EcoRecruit.Application.Recruitment.Languages.Dto;
using EcoRecruit.Recruitment.Applicants;

namespace EcoRecruit.Recruitment.Languages.Dto
{
    public class LanguageMapProfile : Profile
    {
        public LanguageMapProfile()
        {
            CreateMap<CreateLanguageDto, ApplicantLanguage>();
            CreateMap<LanguageDto, ApplicantLanguage>();
            CreateMap<ApplicantLanguage, LanguageDto>();
            
        }
    }
}
