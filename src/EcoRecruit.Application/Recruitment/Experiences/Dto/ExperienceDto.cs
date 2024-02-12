using Abp.AutoMapper;
using Abp.Domain.Entities;
using EcoRecruit.Recruitment.Applicants;
using System;

namespace EcoRecruit.Application.Recruitment.Experiences.Dto
{
    
    [AutoMapFrom(typeof(ApplicantExperience))]
        public class ExperienceDto: Entity<long>
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