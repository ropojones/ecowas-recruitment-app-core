using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using EcoRecruit.Recruitment.Jobs;

namespace EcoRecruit.Application.Recruitment.JobSpecialRequirements.Dto
{
    
    [AutoMapFrom(typeof(JobSpecialRequirement))]
    public class JobSpecialRequirementDto: EntityDto<long>
    {
        public string Requirement { get; set; }
        public string Country { get; set; }

        public int CheckId { get; set; }

        public int JobId { get; set; }

    }
}