using AutoMapper;
using EcoRecruit.Application.Recruitment.JobSpecialRequirements.Dto;
using EcoRecruit.Recruitment.Jobs;

namespace EcoRecruit.Recruitment.JobSpecialRequirements.Dto
{
    public class JobSpecialRequirementMapProfile : Profile
    {
        public JobSpecialRequirementMapProfile()
        {
            CreateMap<CreateJobSpecialRequirementDto, JobSpecialRequirement>();
            CreateMap<JobSpecialRequirementDto, JobSpecialRequirement>();
            CreateMap<JobSpecialRequirement, JobSpecialRequirementDto>();
            
        }
    }
}
