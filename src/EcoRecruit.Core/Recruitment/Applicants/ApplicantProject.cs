using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Applicants
{
    public class ApplicantProject: Entity<long>
    {
        public string Title { get; set; }
        public string  Description { get; set; }
        public long ApplicantId { get; set; }
    public Applicant Applicant { get; set; }
}
}
