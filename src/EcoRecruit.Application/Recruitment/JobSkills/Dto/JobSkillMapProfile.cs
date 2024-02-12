using AutoMapper;
using EcoRecruit.Application.Recruitment.JobSkills.Dto;
using EcoRecruit.Recruitment.Jobs;

namespace EcoRecruit.Recruitment.JobSkills.Dto
{
    public class JobSkillMapProfile : Profile
    {
        public JobSkillMapProfile()
        {
            CreateMap<CreateJobSkillDto, JobSkill>();
            CreateMap<JobSkillDto, JobSkill>();
            CreateMap<JobSkill, JobSkillDto>();
            
        }
    }
}
