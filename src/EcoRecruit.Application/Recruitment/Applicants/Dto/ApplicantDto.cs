using Abp.AutoMapper;
using Abp.Domain.Entities;
using EcoRecruit.Authorization.Users;
using EcoRecruit.Recruitment.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Applicants.Dto
{
    [AutoMapFrom(typeof(Applicant))]
    public class ApplicantDto: Entity<long>
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

        public string? PassportUrl { get; set; }

    }
}
