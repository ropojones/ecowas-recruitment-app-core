using Abp.AutoMapper;
using Abp.Domain.Entities;
using EcoRecruit.Recruitment.Applicants;
using EcoRecruit.Recruitment.Jobs;

namespace EcoRecruit.Application.Recruitment.Jobs.Dto
{
    [AutoMapFrom(typeof(Job))]

    public class JobDto :Entity<int>
    {
        public string Title { get; set; }
        public string JobRefNumber { get; set; }

        public string Institution { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string DutyStation { get; set; }
        public string Deadline { get; set; }
        public string Responsibilities { get; set; }
        public string KeyCompetences { get; set; }
        public string Requirement { get; set; }
        public string Directorate { get; set; }
        public string Department { get; set; }
        public string Division { get; set; }
        public string Supervisor { get; set; }
        public double AnnualSalary { get; set; }
        public int AgeLimit { get; set; }
    }
}