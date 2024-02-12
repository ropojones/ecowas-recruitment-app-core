using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using EcoRecruit.Recruitment.Jobs;

namespace EcoRecruit.Application.Recruitment.JobLanguages.Dto
{
    
    [AutoMapFrom(typeof(JobLanguage))]
        public class JobLanguageDto: EntityDto<long>
    {
        public string Language { get; set; }
        public string Country { get; set; }

        public int CheckId { get; set; }

        public int JobId { get; set; }

    }
}