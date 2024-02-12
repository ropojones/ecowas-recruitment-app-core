using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Checks
{
    public class Check : Entity<int>
    {
        
       
        public string Description { get; set; }

        public Check()
        {
          
        }
        
        public Check(string desc)
        {
            Description = desc;
        }
    }
}