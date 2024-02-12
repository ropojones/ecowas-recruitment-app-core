using Abp.Application.Services.Dto;

namespace EcoRecruit.Recruitment.Countries.Dto
{
    public class PagedCountryResultRequestDto : PagedAndSortedResultRequestDto, IPagedResultRequest
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}
     