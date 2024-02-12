using Abp.AutoMapper;
using Abp.Domain.Entities;
using EcoRecruit.Recruitment.Applicants;

namespace EcoRecruit.Application.Recruitment.Projects.Dto
{
    
    [AutoMapFrom(typeof(ApplicantProject))]
        public class ProjectDto : Entity<long>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public long ApplicantId { get; set; }
    }
}