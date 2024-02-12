using Abp.AutoMapper;
using EcoRecruit.Recruitment.Applicants;

namespace EcoRecruit.Recruitment.CertificatesAwarded.Dto
{
    [AutoMapTo(typeof(ApplicantCertificateAwarded))]
    public class CreateCertificateAwardedDto 
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public string YearReceived { get; set; }
        public long ApplicantId { get; set; }
    }

    
}
