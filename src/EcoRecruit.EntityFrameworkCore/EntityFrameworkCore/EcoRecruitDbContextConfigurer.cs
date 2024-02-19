using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace EcoRecruit.EntityFrameworkCore
{
    public static class EcoRecruitDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<EcoRecruitDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public static void Configure(DbContextOptionsBuilder<EcoRecruitDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); ;
        }
    }
}
