using Abp.AutoMapper;
using EcoRecruit.Recruitment.Applicants;
using System;

namespace EcoRecruit.Recruitment.CoverLetters.Dto
{
    [AutoMapTo(typeof(ApplicantCoverLetter))]
    public class CreateCoverLetterDto 
    {
        public string Letter { get; set; }
        public long ApplicantId { get; set; }

    }


}
