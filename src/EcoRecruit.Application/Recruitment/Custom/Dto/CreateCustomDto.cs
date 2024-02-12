using Abp.AutoMapper;
using EcoRecruit.Recruitment.Applicants;
using System;

namespace EcoRecruit.Recruitment.Customs.Dto
{
    [AutoMapTo(typeof(ApplicantCustom))]
    public class CreateCustomDto 
    {
        public string CustomInfo { get; set; }
        public long ApplicantId { get; set; }
    }

    
}
