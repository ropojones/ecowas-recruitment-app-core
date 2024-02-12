using Abp.AutoMapper;
using Abp.Domain.Entities;
using EcoRecruit.Recruitment.Applicants;
using System;

namespace EcoRecruit.Application.Recruitment.Educations.Dto
{
    
    [AutoMapFrom(typeof(ApplicantEducation))]
    public class EducationDto : Entity<long>
    {
        public string Institution { get; set; }
        public string CertificateAwarded { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public long ApplicantId { get; set; }

    }
}