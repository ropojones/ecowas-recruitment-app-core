using EcoRecruit.Recruitment.Checks;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace EcoRecruit.EntityFrameworkCore.Seed.Host
{
    public class DefaultCheckCreator
    {
        private readonly EcoRecruitDbContext _context;

        public DefaultCheckCreator(EcoRecruitDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            
            AddCheckIfNotExists("Project Management Skill");
            AddCheckIfNotExists("Programme Strategy Implementation");
            AddCheckIfNotExists("Leadership Development");
            AddCheckIfNotExists("Organize work, set priorities and meet deadlines");
            AddCheckIfNotExists("Presentation and reporting skills  ");
            AddCheckIfNotExists("Lead teams and coordinate stakeholders");
            AddCheckIfNotExists("Work program alignment knowledge");
            AddCheckIfNotExists("Organizational goal and objective setting");
            AddCheckIfNotExists("Management Report Writing");
            AddCheckIfNotExists("Information and communications technologies (ICT)Expertise in data analysis and collection");
            AddCheckIfNotExists("Database Management");
            AddCheckIfNotExists("Report Writing");
            AddCheckIfNotExists("Business Acumen");
            AddCheckIfNotExists("Documentation");
            AddCheckIfNotExists("Stakeholder Management");
            AddCheckIfNotExists("English");
            AddCheckIfNotExists("Portuguese");
            AddCheckIfNotExists("French");
            AddCheckIfNotExists("Other");
            AddCheckIfNotExists("Ability to respect the chain of command in an appropriate manner.");
            AddCheckIfNotExists("Self-Regulated and Good Work Ethic");
            AddCheckIfNotExists("Time management");
            AddCheckIfNotExists("Knowledge of techniques to prioritize tasks in a fast-paced workplace with frequent interruptions.");
            AddCheckIfNotExists("Ability to influence positive teamwork and cooperation.");
            AddCheckIfNotExists("Internal and External Interpersonal Relationship");
            AddCheckIfNotExists("Information flow management");
            AddCheckIfNotExists("Ability to condense information and/or produce concise summary notes to help others with decision-making, problem-solving and/or assessment of work.");
            AddCheckIfNotExists("Ability to make decisions based on guidelines, procedures and precedents and maintain confidentiality and discretion with clients.");
            AddCheckIfNotExists("Good judgment and demonstrated ability to be assertive – rather than passive or aggressive when interacting with clients.");
            AddCheckIfNotExists("Well-developed problem-solving, critical thinking and conflict-resolution skills.");
            AddCheckIfNotExists("Ability to perceive the moods and feelings of others, and to understand the attitude, interests, needs, and perspectives of others.");
            AddCheckIfNotExists("Respect for Diversity and Divergent views");
            AddCheckIfNotExists("Ability and responsibility for incorporating gender perspectives and ensuring the equal participation of women and men in all areas of work.");
            AddCheckIfNotExists("Understanding of ECOWAS Mandate and Culture");
            AddCheckIfNotExists("Understanding and adherence to the policies, procedures and guidelines required to support the ECOWAS planning cycle at the individual and organizational levels.");
            AddCheckIfNotExists("Functional Report Accuracy");
            AddCheckIfNotExists("Technologically Savvy");

        }

        private void AddCheckIfNotExists(string description)
        {
            if (_context.Checks.IgnoreQueryFilters().Any(vt => vt.Description == description))
            {
                return;
            }

            _context.Checks.Add(new Check(description));
            _context.SaveChanges();
        }
    }
}
