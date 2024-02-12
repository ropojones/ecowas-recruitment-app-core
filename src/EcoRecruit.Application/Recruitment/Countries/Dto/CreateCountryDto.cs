using Abp.AutoMapper;
using System;

namespace EcoRecruit.Recruitment.Countries.Dto
{
    [AutoMapTo(typeof(Country))]
    public class CreateCountryDto 
    {
        public string CountryName { get; set; }
    }

    
}
