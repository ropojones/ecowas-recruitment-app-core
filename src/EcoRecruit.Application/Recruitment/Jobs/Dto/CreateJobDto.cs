using Abp.AutoMapper;
using System;

namespace EcoRecruit.Recruitment.Jobs.Dto
{
    [AutoMapTo(typeof(Job))]
    public class CreateJobDto 
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string JobRefNumber { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public string Deadline { get; set; }
        public string Responsibilities { get; set; }
        public string Requirement { get; set; }
    }

    
}
