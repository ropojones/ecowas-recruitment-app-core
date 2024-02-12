using Abp.Application.Services.Dto;

namespace EcoRecruit.Recruitment.CoverLetters.Dto
{
    public class PagedCoverLetterResultRequestDto : PagedAndSortedResultRequestDto, IPagedResultRequest
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}
     