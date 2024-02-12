using Abp.Application.Services.Dto;

namespace EcoRecruit.Recruitment.ValueTypesData.Dto
{
    public class PagedValueTypeDataResultRequestDto : PagedAndSortedResultRequestDto, IPagedResultRequest
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}
     