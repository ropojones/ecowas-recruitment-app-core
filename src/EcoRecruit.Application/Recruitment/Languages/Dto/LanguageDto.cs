using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using EcoRecruit.Recruitment.Applicants;

namespace EcoRecruit.Application.Recruitment.Languages.Dto
{
    
    [AutoMapFrom(typeof(ApplicantLanguage))]
        public class LanguageDto : EntityDto<long>
    {
        public string LanguageString { get; set; }
        public long ApplicantId { get; set; }

    }
}