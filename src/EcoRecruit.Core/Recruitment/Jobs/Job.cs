using Abp.Domain.Entities;
using EcoRecruit.Recruitment.Applicants;
using System.Collections.Generic;

namespace EcoRecruit.Recruitment.Jobs
{
    public class Job : Entity <int>
    {
        public string Title { get; set; }
        public string Institution { get; set; }
        public int Year { get; set; }
        public string JobRefNumber { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public string Deadline { get; set; }
        public string Responsibilities { get; set; }
        public string Requirement { get; set; }    

        public ICollection<Applicant> Applicants { get; set; }
        public virtual ICollection<JobLanguage> JobLanguages {get;set;}
        public virtual ICollection<JobSkill> JobSkills {get;set;}        
        public virtual ICollection<JobEcowasCompetence> JobEcowasCompetences {get;set;}        
        public virtual ICollection<JobSpecialRequirement> JobSpecialRequirements {get;set;}
    }
}