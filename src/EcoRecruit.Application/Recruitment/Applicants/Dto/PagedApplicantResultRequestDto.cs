using Abp.Application.Services.Dto;

namespace EcoRecruit.Recruitment.Applicants.Dto
{
    public class PagedApplicantResultRequestDto : PagedAndSortedResultRequestDto, IPagedResultRequest
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}
     