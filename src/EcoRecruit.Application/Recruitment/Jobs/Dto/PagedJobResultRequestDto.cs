using Abp.Application.Services.Dto;

namespace EcoRecruit.Recruitment.Jobs.Dto
{
    public class PagedJobResultRequestDto : PagedAndSortedResultRequestDto, IPagedResultRequest
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}
     