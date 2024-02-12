namespace EcoRecruit.EntityFrameworkCore.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly EcoRecruitDbContext _context;

        public InitialHostDbBuilder(EcoRecruitDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
            new DefaultValueTypesCreator(_context).Create();
            new DefaultValueTypeDataCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
