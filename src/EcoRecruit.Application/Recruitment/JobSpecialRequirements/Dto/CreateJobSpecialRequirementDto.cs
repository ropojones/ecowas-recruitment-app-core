using Abp.AutoMapper;
using EcoRecruit.Recruitment.Jobs;
using System;

namespace EcoRecruit.Recruitment.JobSpecialRequirements.Dto
{
    [AutoMapTo(typeof(JobSpecialRequirement))]
    public class CreateJobSpecialRequirementDto 
    {
        public string Requirement { get; set; }
        public string Country { get; set; }

        public int CheckId { get; set; }

        public int JobId { get; set; }

    }


}
