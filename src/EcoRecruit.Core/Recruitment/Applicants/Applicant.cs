using Abp;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using EcoRecruit.Recruitment.Applications;
using EcoRecruit.Recruitment.Jobs;
using System;
using System.Collections.Generic;

namespace EcoRecruit.Recruitment.Applicants
{
    public class Applicant : Entity<long>
    {

        public string ApplicantNumber { get; set; }
        public string Headline { get; set; }
        public int YearsOfExperience { get; set; }
        public string AboutMe { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public int? Age { get; set; }
        public string Phone { get; set; }
        public string AlternatePhone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string EducationLevel { get; set; }
        public string CourseOfStudy { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public long UserId { get; set; }
        public bool? IsEcowas { get; set; }
        public bool? IsEcowasVerified { get; set; }
        public string? Availability { get; set; }

        public virtual ICollection<Job> Jobs { get; } = []; 
        public virtual ICollection<ApplicantCertificateAwarded> CertificatesAwarded { get; set; } 
        public virtual ICollection<ApplicantCoverLetter> CoverLetters { get; set; }  
        public virtual ICollection<ApplicantCustom> Customs { get; set; }  
        public virtual ICollection<ApplicantEducation> Educations { get; set; }  
        public virtual ICollection<ApplicantExperience> Experiences { get; set; } 
        public virtual ICollection<ApplicantLanguage> Languages { get; set; }  
        public virtual ICollection<ApplicantProject> Projects { get; set; }      
        public virtual ICollection<ApplicantSkill> Skills { get; set; }  
        public virtual ICollection<ApplicantTraining> Trainings { get; set; } 

    }
}