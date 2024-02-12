using Abp.Application.Services.Dto;

namespace EcoRecruit.Recruitment.Skills.Dto
{
    public class PagedSkillResultRequestDto : PagedAndSortedResultRequestDto, IPagedResultRequest
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}
     