using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.ValueTypes
{
    public class ValueTypeData : Entity<int>
    {
        public ValueTypeData(string name, int order, string vType)
        {
            Name = name;
            Order = order;
            VType = vType;
        }

        public string Name { get; set; }

        public int Order { get; set; }

        public string VType { get; set; }
    }
}  