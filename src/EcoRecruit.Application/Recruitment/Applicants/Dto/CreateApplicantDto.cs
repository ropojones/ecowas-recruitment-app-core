using Abp.AutoMapper;
using System;

namespace EcoRecruit.Recruitment.Applicants.Dto
{
    [AutoMapTo(typeof(Applicant))]
    public class CreateApplicantDto 
    {
        public string AboutMe { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Middle { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string AlternatePhone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string EducationLevel { get; set; }
        public string CourseOfStudy { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public long UserId { get; set; }
        public bool HasEcowasHistory { get; set; } 
    }

    
}
