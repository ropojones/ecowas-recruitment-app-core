using Abp.AutoMapper;
using Abp.Domain.Entities;
using EcoRecruit.Recruitment.Applicants;

namespace EcoRecruit.Application.Recruitment.Customs.Dto
{
    
    [AutoMapFrom(typeof(ApplicantCustom))]
    public class CustomDto : Entity<long>
    {
        public string CustomInfo { get; set; }
        public long ApplicantId { get; set; }
    }
}