using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using EcoRecruit.Recruitment.Applicants;

namespace EcoRecruit.Application.Recruitment.Skills.Dto
{
    
    [AutoMapFrom(typeof(ApplicantSkill))]
        public class SkillDto: EntityDto<long>
    {
        public string SkillString { get; set; }
        public string Description { get; set; }

        public long ApplicantId { get; set; }

    }
}