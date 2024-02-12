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
        public string Institution { get; set; }

        public string JobRefNumber { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public string Deadline { get; set; }
        public string Responsibilities { get; set; }
        public string Requirement { get; set; }
    }
}