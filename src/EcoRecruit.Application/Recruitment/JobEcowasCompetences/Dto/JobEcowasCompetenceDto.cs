using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using EcoRecruit.Recruitment.Jobs;

namespace EcoRecruit.Application.Recruitment.JobEcowasCompetences.Dto
{
    
    [AutoMapFrom(typeof(JobEcowasCompetence))]
    public class JobEcowasCompetenceDto: EntityDto<long>
    {
        public string Competence { get; set; }
        public string Country { get; set; }

        public int CheckId { get; set; }

        public int JobId { get; set; }
    }
}