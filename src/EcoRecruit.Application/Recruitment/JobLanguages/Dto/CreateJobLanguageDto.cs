using Abp.AutoMapper;
using EcoRecruit.Recruitment.Jobs;
using System;

namespace EcoRecruit.Recruitment.JobLanguages.Dto
{
    [AutoMapTo(typeof(JobLanguage))]
    public class CreateJobLanguageDto 
    {
        public string Language { get; set; }
        public string Country { get; set; }

        public int CheckId { get; set; }

        public int JobId { get; set; }

    }


}
