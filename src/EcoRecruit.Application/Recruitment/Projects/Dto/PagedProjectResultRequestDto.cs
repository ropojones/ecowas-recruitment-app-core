using Abp.Application.Services.Dto;

namespace EcoRecruit.Recruitment.Projects.Dto
{
    public class PagedProjectResultRequestDto : PagedAndSortedResultRequestDto, IPagedResultRequest
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}
     