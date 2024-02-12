using Abp.AutoMapper;
using Abp.Domain.Entities;
using EcoRecruit.Authorization.Users;
using EcoRecruit.Recruitment.Applicants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.CertificatesAwarded.Dto
{
    [AutoMapFrom(typeof(ApplicantCertificateAwarded))]
    public class CertificateAwardedDto: Entity<long>
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public string YearReceived { get; set; }
        public long ApplicantId { get; set; }

    }
}



