using Abp.AutoMapper;
using System;

namespace EcoRecruit.Recruitment.ValueTypes.Dto
{
    [AutoMapTo(typeof(ValueType))]
    public class CreateValueTypeDto 
    {
        public string Name { get; set; }
    }

    
}
