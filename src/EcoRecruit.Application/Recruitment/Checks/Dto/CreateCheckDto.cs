using Abp.AutoMapper;
using System;

namespace EcoRecruit.Recruitment.Checks.Dto
{
    [AutoMapTo(typeof(Check))]
    public class CreateCheckDto 
    {
        public string Description { get; set; }
    }

    
}
