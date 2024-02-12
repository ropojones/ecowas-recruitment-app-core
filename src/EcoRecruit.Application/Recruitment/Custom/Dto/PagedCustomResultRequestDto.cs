using Abp.Application.Services.Dto;

namespace EcoRecruit.Recruitment.Customs.Dto
{
    public class PagedCustomResultRequestDto : PagedAndSortedResultRequestDto, IPagedResultRequest
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}
     