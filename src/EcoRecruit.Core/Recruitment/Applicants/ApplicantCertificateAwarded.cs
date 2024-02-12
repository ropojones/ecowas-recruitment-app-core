using Abp.Domain.Entities;

namespace EcoRecruit.Recruitment.Applicants
{
    public  class ApplicantCertificateAwarded: Entity<long>
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public string YearReceived { get; set; }
        public long ApplicantId { get; set; }
        public Applicant Applicant { get; set; }

    
    }
}
