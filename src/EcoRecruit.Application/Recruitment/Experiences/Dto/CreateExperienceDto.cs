using Abp.AutoMapper;
using EcoRecruit.Recruitment.Applicants;
using System;

namespace EcoRecruit.Recruitment.Experiences.Dto
{
    [AutoMapTo(typeof(ApplicantExperience))]
    public class CreateExperienceDto 
    {
        public string Organization { get; set; }
        public string Responsibiities { get; set; }
        public string JobTitle { get; set; }
        public string Level { get; set; }
        public string Function { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long ApplicantId { get; set; }

    }


}
