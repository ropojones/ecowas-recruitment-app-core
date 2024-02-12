using AutoMapper;
using EcoRecruit.Recruitment.Checks.Dto;

namespace EcoRecruit.Recruitment.Checks.Dto
{
    public class CheckMapProfile : Profile
    {
        public CheckMapProfile()
        {
            CreateMap<CreateCheckDto, Check>();
            CreateMap<CheckDto, Check>();
            CreateMap<Check, CheckDto>();
            
        }
    }
}
