using Abp.Application.Services.Dto;

namespace EcoRecruit.Recruitment.JobLanguages.Dto
{
    public class PagedJobLanguageResultRequestDto : PagedAndSortedResultRequestDto, IPagedResultRequest
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}
     