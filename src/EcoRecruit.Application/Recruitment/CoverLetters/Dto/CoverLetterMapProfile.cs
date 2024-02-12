using AutoMapper;
using EcoRecruit.Application.Recruitment.CoverLetters.Dto;
using EcoRecruit.Recruitment.Applicants;

namespace EcoRecruit.Recruitment.CoverLetters.Dto
{
    public class CoverLetterMapProfile : Profile
    {
        public CoverLetterMapProfile()
        {
            CreateMap<CreateCoverLetterDto, ApplicantCoverLetter>();
            CreateMap<CoverLetterDto, ApplicantCoverLetter>();
            CreateMap<ApplicantCoverLetter, CoverLetterDto>();
            
        }
    }
}
