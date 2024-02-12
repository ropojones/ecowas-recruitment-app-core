using Abp.Application.Services.Dto;

namespace EcoRecruit.Application.Recruitment.CoverLetters.Dto
{
    public class CoverLetterDto : EntityDto<long>
    {
        public string Letter { get; set; }
        public long ApplicantId { get; set; }

    }
}