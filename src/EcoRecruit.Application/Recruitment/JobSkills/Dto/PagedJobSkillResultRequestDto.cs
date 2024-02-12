using Abp.Application.Services.Dto;

namespace EcoRecruit.Recruitment.JobSkills.Dto
{
    public class PagedJobSkillResultRequestDto : PagedAndSortedResultRequestDto, IPagedResultRequest
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}
     