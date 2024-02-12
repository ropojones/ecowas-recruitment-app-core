using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using EcoRecruit.Recruitment.Jobs;

namespace EcoRecruit.Application.Recruitment.JobSkills.Dto
{
    
    [AutoMapFrom(typeof(JobSkill))]
        public class JobSkillDto: EntityDto<long>
    {
        public string Skill { get; set; }
        public string Country { get; set; }

        public int CheckId { get; set; }

        public int JobId { get; set; }
    }
}