using Abp.AutoMapper;
using EcoRecruit.Recruitment.Applicants;
using System;

namespace EcoRecruit.Recruitment.Projects.Dto
{
    [AutoMapTo(typeof(ApplicantProject))]
    public class CreateProjectDto 
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public long ApplicantId { get; set; }
    }

    
}
