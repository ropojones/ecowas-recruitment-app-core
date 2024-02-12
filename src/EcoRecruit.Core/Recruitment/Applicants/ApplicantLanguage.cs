using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Applicants
{
    public class ApplicantLanguage: Entity<long>
    {
        public string LanguageString { get; set; }
        public long ApplicantId { get; set; }
        public Applicant Applicant { get; set; }
    }
}
