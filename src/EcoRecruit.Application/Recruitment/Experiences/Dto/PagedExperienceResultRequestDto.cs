using Abp.Application.Services.Dto;

namespace EcoRecruit.Recruitment.Experiences.Dto
{
    public class PagedExperienceResultRequestDto : PagedAndSortedResultRequestDto, IPagedResultRequest
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}
     