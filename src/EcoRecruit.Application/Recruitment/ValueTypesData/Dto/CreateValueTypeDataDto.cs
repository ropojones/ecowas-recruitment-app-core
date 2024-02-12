using Abp.AutoMapper;
using EcoRecruit.Recruitment.ValueTypes;
using System;

namespace EcoRecruit.Recruitment.ValueTypesData.Dto
{
    [AutoMapTo(typeof(ValueTypeData))]
    public class CreateValueTypeDataDto 
    {
        public string Name { get; set; }

        public int Order { get; set; }

        public string VType { get; set; }

    }

    
}
