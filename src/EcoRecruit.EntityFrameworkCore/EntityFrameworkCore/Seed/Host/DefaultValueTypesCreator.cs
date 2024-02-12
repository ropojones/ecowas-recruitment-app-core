using System.Linq;
using Microsoft.EntityFrameworkCore;
using Abp.Configuration;
using Abp.Localization;
using Abp.MultiTenancy;
using Abp.Net.Mail;
using EcoRecruit.Recruitment.ValueTypes;

namespace EcoRecruit.EntityFrameworkCore.Seed.Host
{
    public class DefaultValueTypesCreator
    {
        private readonly EcoRecruitDbContext _context;
         public DefaultValueTypesCreator(EcoRecruitDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            AddValueTypeIfNotExists("Skills");
            AddValueTypeIfNotExists("Language");
            AddValueTypeIfNotExists("Special");
            AddValueTypeIfNotExists("Competence");
          }

        private void AddValueTypeIfNotExists(string name)
        {
            if (_context.ValueTypes.IgnoreQueryFilters().Any(vt=> vt.Name == name))
            {
                return;
            }

            _context.ValueTypes.Add(new ValueType(name));
            _context.SaveChanges();
        }
    }
}
