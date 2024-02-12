using Abp.AutoMapper;
using EcoRecruit.Recruitment.Applicants;
using System;

namespace EcoRecruit.Recruitment.Skills.Dto
{
    [AutoMapTo(typeof(ApplicantSkill))]
    public class CreateSkillDto 
    {
        public string SkillString { get; set; }
        public string Description { get; set; }

        public long ApplicantId { get; set; }
    }

    
}
