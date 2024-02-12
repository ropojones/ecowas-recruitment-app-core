using Abp.Domain.Entities;
using EcoRecruit.Recruitment.Applicants;
using EcoRecruit.Recruitment.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Applications
{
    public class Application : Entity<long>
    {
        public string JobRefNumber { get; set; }
        public string ApplicationNumber { get; set; }
        public byte[] Data { get; set; }
        public string ApplicantNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string EducationLevel { get; set; }
        
        public string CourseOfStudy { get; set; }
        
        public string Country { get; set; }
        
        public long UserId { get; set; }
        
        public bool HasEcowasHistory { get; set; }

        public int JobId { get; set; }
        public Job Job { get; set; }

        public long ApplicantId { get; set; }

        public Applicant Applicant { get; set; }


    }
}
