using Abp.Application.Services.Dto;

namespace EcoRecruit.Recruitment.Trainings.Dto
{
    public class PagedTrainingResultRequestDto : PagedAndSortedResultRequestDto, IPagedResultRequest
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}
     