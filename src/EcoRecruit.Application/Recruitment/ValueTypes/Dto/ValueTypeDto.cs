using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using EcoRecruit.Recruitment.ValueTypes;

namespace EcoRecruit.Application.Recruitment.ValueTypes.Dto
{
    
    [AutoMapFrom(typeof(ValueType))]
        public class ValueTypeDto: EntityDto<int>
    {
        public string Name { get; set; }
    }
}