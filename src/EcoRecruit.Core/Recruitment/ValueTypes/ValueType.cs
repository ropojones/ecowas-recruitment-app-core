using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.ValueTypes
{
    public class ValueType : Entity<int>
    {
        public string Name { get; set; }

 
        // Types = Skill, Special, Language, Competence,

        public ValueType(string name)
        {
            Name = name;
        }

    }
}