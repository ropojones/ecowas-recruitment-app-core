using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Checks.Dto
{
    [AutoMapFrom(typeof(Check))]
    public class CheckDto: Entity<int>
    {
        public string Description { get; set; }
    }
}



