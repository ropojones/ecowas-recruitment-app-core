using Abp.Domain.Entities;
using System;

namespace EcoRecruit.Recruitment.Applicants
{
    public class ApplicantEducation : Entity<long>
    {
        public string Institution { get; set; }
        public string CertificateAwarded { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public long ApplicantId { get; set; }
        public Applicant Applicant { get; set; }
    }
      

}