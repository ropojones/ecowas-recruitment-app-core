using Abp.Domain.Entities;
using System;

namespace EcoRecruit.Recruitment.Applicants
{
    public class ApplicantExperience : Entity<long>
    { 
        public string Organization { get; set; }
        public string Responsibiities { get; set; }
        public string JobTitle { get; set; }
        public string Level { get; set; }
        public string Function { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
       public long ApplicantId { get; set; }
        public Applicant Applicant { get; set; }

    }


}