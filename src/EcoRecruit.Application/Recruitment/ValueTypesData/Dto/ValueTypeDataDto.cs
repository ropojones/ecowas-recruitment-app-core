using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using EcoRecruit.Recruitment.ValueTypes;

namespace EcoRecruit.Application.Recruitment.ValueTypesData.Dto
{
    
    [AutoMapFrom(typeof(ValueTypeData))]
        public class ValueTypeDataDto: EntityDto<int>
    {
        public string Name { get; set; }

        public int Order { get; set; }

        public string VType { get; set; }
    }
}