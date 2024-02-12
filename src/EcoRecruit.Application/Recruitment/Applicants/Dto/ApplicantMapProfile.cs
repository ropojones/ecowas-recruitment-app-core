using AutoMapper;

namespace EcoRecruit.Recruitment.Applicants.Dto
{
    public class ApplicantMapProfile : Profile
    {
        public ApplicantMapProfile()
        {
            CreateMap<CreateApplicantDto, Applicant>();
            CreateMap<ApplicantDto, Applicant>();
            CreateMap<Applicant, ApplicantDto>();
            
        }
    }
}
