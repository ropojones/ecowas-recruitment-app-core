using Abp.AutoMapper;
using EcoRecruit.Recruitment.Jobs;
using System;

namespace EcoRecruit.Recruitment.JobEcowasCompetences.Dto
{
    [AutoMapTo(typeof(JobEcowasCompetence))]
    public class CreateJobEcowasCompetenceDto 
    {
        public string Competence { get; set; }
        public string Country { get; set; }

        public int CheckId { get; set; }

        public int JobId { get; set; }

    }


}
