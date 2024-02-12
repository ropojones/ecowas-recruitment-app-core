using Abp.Application.Services.Dto;

namespace EcoRecruit.Recruitment.Checks.Dto
{
    public class PagedCheckResultRequestDto : PagedAndSortedResultRequestDto, IPagedResultRequest
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}
     