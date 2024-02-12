using AutoMapper;
using EcoRecruit.Application.Recruitment.ValueTypes.Dto;

namespace EcoRecruit.Recruitment.ValueTypes.Dto
{
    public class ValueTypeMapProfile : Profile
    {
        public ValueTypeMapProfile()
        {
            CreateMap<CreateValueTypeDto, ValueType>();
            CreateMap<ValueTypeDto, ValueType>();
            CreateMap<ValueType, ValueTypeDto>();
            
        }
    }
}
