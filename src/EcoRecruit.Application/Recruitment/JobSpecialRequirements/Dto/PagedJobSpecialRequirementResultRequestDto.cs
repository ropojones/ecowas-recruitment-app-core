using Abp.Application.Services.Dto;

namespace EcoRecruit.Recruitment.JobSpecialRequirements.Dto
{
    public class PagedJobSpecialRequirementResultRequestDto : PagedAndSortedResultRequestDto, IPagedResultRequest
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}
     