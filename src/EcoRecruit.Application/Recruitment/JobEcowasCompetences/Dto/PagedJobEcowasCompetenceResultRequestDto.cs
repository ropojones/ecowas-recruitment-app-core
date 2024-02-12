using Abp.Application.Services.Dto;

namespace EcoRecruit.Recruitment.JobEcowasCompetences.Dto
{
    public class PagedJobEcowasCompetenceResultRequestDto : PagedAndSortedResultRequestDto, IPagedResultRequest
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}
     