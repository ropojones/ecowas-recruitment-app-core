using Abp.Application.Services.Dto;

namespace EcoRecruit.Recruitment.Educations.Dto
{
    public class PagedEducationResultRequestDto : PagedAndSortedResultRequestDto, IPagedResultRequest
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}
     