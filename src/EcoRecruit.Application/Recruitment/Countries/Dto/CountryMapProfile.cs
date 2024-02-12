using AutoMapper;
using EcoRecruit.Application.Recruitment.Countries.Dto;

namespace EcoRecruit.Recruitment.Countries.Dto
{
    public class CountryMapProfile : Profile
    {
        public CountryMapProfile()
        {
            CreateMap<CreateCountryDto, Country>();
            CreateMap<CountryDto, Country>();
            CreateMap<Country, CountryDto>();
            
        }
    }
}
