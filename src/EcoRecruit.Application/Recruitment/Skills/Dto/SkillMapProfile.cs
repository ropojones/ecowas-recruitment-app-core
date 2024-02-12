using AutoMapper;
using EcoRecruit.Application.Recruitment.Skills.Dto;
using EcoRecruit.Recruitment.Applicants;

namespace EcoRecruit.Recruitment.Skills.Dto
{
    public class SkillMapProfile : Profile
    {
        public SkillMapProfile()
        {
            CreateMap<CreateSkillDto, ApplicantSkill>();
            CreateMap<SkillDto, ApplicantSkill>();
            CreateMap<ApplicantSkill, SkillDto>();
            
        }
    }
}
