using Abp.AutoMapper;
using EcoRecruit.Recruitment.Applicants;
using System;

namespace EcoRecruit.Recruitment.Languages.Dto
{
    [AutoMapTo(typeof(ApplicantLanguage))]
    public class CreateLanguageDto 
    {
        public string LanguageString { get; set; }
        public long ApplicantId { get; set; }
    }

    
}
