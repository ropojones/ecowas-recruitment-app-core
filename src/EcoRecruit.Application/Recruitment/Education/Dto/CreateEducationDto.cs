using Abp.AutoMapper;
using EcoRecruit.Recruitment.Applicants;
using System;

namespace EcoRecruit.Recruitment.Educations.Dto
{
    [AutoMapTo(typeof(ApplicantEducation))]
    public class CreateEducationDto 
    {
        public string Institution { get; set; }
        public string CertificateAwarded { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public long ApplicantId { get; set; }

    }


}
