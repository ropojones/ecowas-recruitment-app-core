using Abp.AutoMapper;
using System;

namespace EcoRecruit.Recruitment.Applications.Dto
{
    [AutoMapTo(typeof(Application))]
    public class CreateApplicationDto 
    {
        public string ApplicationNumber { get; set; }

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
    
        public int ApplicantId { get; set; }

      
    }

    
}
