using Abp.AutoMapper;
using EcoRecruit.Recruitment.Jobs;
using System;

namespace EcoRecruit.Recruitment.JobSkills.Dto
{
    [AutoMapTo(typeof(JobSkill))]
    public class CreateJobSkillDto 
    {
        public string Skill { get; set; }
        public string Country { get; set; }

        public int CheckId { get; set; }


        public int JobId { get; set; }
    }

    
}
