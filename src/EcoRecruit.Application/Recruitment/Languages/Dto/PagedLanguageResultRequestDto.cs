using Abp.Application.Services.Dto;

namespace EcoRecruit.Recruitment.Languages.Dto
{
    public class PagedLanguageResultRequestDto : PagedAndSortedResultRequestDto, IPagedResultRequest
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}
     