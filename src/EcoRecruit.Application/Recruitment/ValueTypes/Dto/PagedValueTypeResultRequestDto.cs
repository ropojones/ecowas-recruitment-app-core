using Abp.Application.Services.Dto;

namespace EcoRecruit.Recruitment.ValueTypes.Dto
{
    public class PagedValueTypeResultRequestDto : PagedAndSortedResultRequestDto, IPagedResultRequest
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}
     