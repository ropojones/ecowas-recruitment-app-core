using System;

using Abp.Domain.Entities;

namespace EcoRecruit.Recruitment.Applicants
{
    public class ApplicantTraining: Entity<long>
    {

        public string Organization { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
 
        public long ApplicantId { get; set; }
        public Applicant Applicant { get; set; }



    }

}