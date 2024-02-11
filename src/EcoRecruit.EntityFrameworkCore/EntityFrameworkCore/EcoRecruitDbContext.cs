using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using EcoRecruit.Authorization.Roles;
using EcoRecruit.Authorization.Users;
using EcoRecruit.MultiTenancy;

namespace EcoRecruit.EntityFrameworkCore
{
    public class EcoRecruitDbContext : AbpZeroDbContext<Tenant, Role, User, EcoRecruitDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public EcoRecruitDbContext(DbContextOptions<EcoRecruitDbContext> options)
            : base(options)
        {
        }
    }
}
