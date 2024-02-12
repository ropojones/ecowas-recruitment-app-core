using AutoMapper;
using EcoRecruit.Application.Recruitment.Jobs.Dto;

namespace EcoRecruit.Recruitment.Jobs.Dto
{
    public class JobMapProfile : Profile
    {
        public JobMapProfile()
        {
            CreateMap<CreateJobDto, Job>();
            CreateMap<JobDto, Job>();
            CreateMap<Job, JobDto>();
            
        }
    }
}
