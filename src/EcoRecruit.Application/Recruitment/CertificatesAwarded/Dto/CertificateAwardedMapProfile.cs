using AutoMapper;
using EcoRecruit.Recruitment.Applicants;

namespace EcoRecruit.Recruitment.CertificatesAwarded.Dto
{
    public class CertificateAwardedMapProfile : Profile
    {
        public CertificateAwardedMapProfile()
        {
            CreateMap<CreateCertificateAwardedDto, ApplicantCertificateAwarded>();
            CreateMap<CertificateAwardedDto, ApplicantCertificateAwarded>();
            CreateMap<ApplicantCertificateAwarded, CertificateAwardedDto>();
            
        }
    }
}
