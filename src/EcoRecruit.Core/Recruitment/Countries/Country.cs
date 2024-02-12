using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Countries
{
    public class Country: Entity<int>
    {
        public string CountryName { get; set; }
    
        
    
    }
}