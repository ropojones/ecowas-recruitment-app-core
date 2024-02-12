using AutoMapper;
using EcoRecruit.Application.Recruitment.ValueTypesData.Dto;
using EcoRecruit.Recruitment.ValueTypes;

namespace EcoRecruit.Recruitment.ValueTypesData.Dto
{
    public class ValueTypeDataMapProfile : Profile
    {
        public ValueTypeDataMapProfile()
        {
            CreateMap<CreateValueTypeDataDto, ValueTypeData>();
            CreateMap<ValueTypeDataDto, ValueTypeData>();
            CreateMap<ValueTypeData, ValueTypeDataDto>();
            
        }
    }
}
