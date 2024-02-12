using EcoRecruit.Recruitment.ValueTypes;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EcoRecruit.EntityFrameworkCore.Seed.Host
{
    public class DefaultValueTypeDataCreator
    {
        private readonly EcoRecruitDbContext _context;

        public DefaultValueTypeDataCreator(EcoRecruitDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            AddValueTypeDataIfNotExists("Expert", 0, "Skill");
            AddValueTypeDataIfNotExists("Intermediate", 1, "Skill");
            AddValueTypeDataIfNotExists("Basic", 2, "Skill");
            AddValueTypeDataIfNotExists("Need Supervision", 3, "Skill");
            AddValueTypeDataIfNotExists("No skill at all", 4, "Skill");


            AddValueTypeDataIfNotExists("Basic", 0, "Language");
            AddValueTypeDataIfNotExists("Intermediate", 1, "Language");
            AddValueTypeDataIfNotExists("Expert", 2, "Language");
            AddValueTypeDataIfNotExists("No level of Proficiency", 3, "Language");


            AddValueTypeDataIfNotExists("Beginner", 0, "Competence");
            AddValueTypeDataIfNotExists("Intermediate", 1, "Competence");
            AddValueTypeDataIfNotExists("Proficient", 2, "Competence");
            AddValueTypeDataIfNotExists("Expert", 3, "Competence");


            AddValueTypeDataIfNotExists("Yes", 0, "Special");
            AddValueTypeDataIfNotExists("No", 1, "Special");
           


        }

        private void AddValueTypeDataIfNotExists(string name, int order, string vtype)
        {
            if (_context.ValueTypeDatas.IgnoreQueryFilters().Any(vt => vt.Name == name && vt.Order == order && vt.VType == vtype))
            {
                return;
            }

            _context.ValueTypeDatas.Add(new ValueTypeData(name, order, vtype));
            _context.SaveChanges();
        }
    }
}
 