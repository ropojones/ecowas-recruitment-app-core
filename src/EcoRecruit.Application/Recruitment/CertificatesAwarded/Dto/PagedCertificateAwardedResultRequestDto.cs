using Abp.Application.Services.Dto;

namespace EcoRecruit.Recruitment.CertificatesAwarded.Dto
{
    public class PagedCertificateAwardedResultRequestDto : PagedAndSortedResultRequestDto, IPagedResultRequest
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}
     