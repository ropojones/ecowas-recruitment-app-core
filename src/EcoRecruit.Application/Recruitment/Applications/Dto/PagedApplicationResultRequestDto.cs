using Abp.Application.Services.Dto;

namespace EcoRecruit.Recruitment.Applications.Dto
{
    public class PagedApplicationResultRequestDto : PagedAndSortedResultRequestDto, IPagedResultRequest
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}
     