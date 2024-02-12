using AutoMapper;
using EcoRecruit.Application.Recruitment.JobLanguages.Dto;
using EcoRecruit.Recruitment.Jobs;

namespace EcoRecruit.Recruitment.JobLanguages.Dto
{
    public class JobLanguageMapProfile : Profile
    {
        public JobLanguageMapProfile()
        {
            CreateMap<CreateJobLanguageDto, JobLanguage>();
            CreateMap<JobLanguageDto, JobLanguage>();
            CreateMap<JobLanguage, JobLanguageDto>();
            
        }
    }
}
