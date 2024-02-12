using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using EcoRecruit.Authorization.Roles;
using EcoRecruit.Authorization.Users;
using EcoRecruit.MultiTenancy;
using EcoRecruit.Recruitment.Jobs;
using EcoRecruit.Recruitment.Applications;
using EcoRecruit.Recruitment.Applicants;
using EcoRecruit.Recruitment.Countries;
using EcoRecruit.Recruitment.ValueTypes;
using EcoRecruit.Recruitment.Checks;


namespace EcoRecruit.EntityFrameworkCore
{
    public class EcoRecruitDbContext : AbpZeroDbContext<Tenant, Role, User, EcoRecruitDbContext>
    {
        /* Define a DbSet for each entity of the Applicant */
        public DbSet<Application> ApplicationsData { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<ApplicantCertificateAwarded> ApplicantCertificateAwards { get; set; }
        public DbSet<ApplicantCoverLetter> ApplicantCoverLetters { get; set; }
        public DbSet<ApplicantCustom> ApplicantCustoms { get; set; }
        public DbSet<ApplicantEducation> ApplicantEducations { get; set; }
        public DbSet<ApplicantExperience> ApplicantExperiences { get; set; }
        public DbSet<ApplicantLanguage> ApplicantLanguages { get; set; }
        public DbSet<ApplicantSkill> ApplicantSkills { get; set; }
        public DbSet<ApplicantTraining> ApplicantTrainings { get; set; }
        public DbSet<Check> Checks { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobEcowasCompetence> JobEcowasCompetences { get; set; }
        public DbSet<JobLanguage> JobLanguages { get; set; }
        public DbSet<JobSkill> JobSkills { get; set; }
        public DbSet<JobSpecialRequirement> JobSpecialRequirements { get; set; }
        public DbSet<ValueType> ValueTypes { get; set; }
        public DbSet<ValueTypeData> ValueTypeDatas { get; set; }

        public EcoRecruitDbContext(DbContextOptions<EcoRecruitDbContext> options)
            : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Application>().HasOne<Applicant>(app => app.Applicant).WithMany(ap => ap.Applications).HasForeignKey(app => app.ApplicantId).OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<Application>().HasIndex(app => new { app.JobId, app.ApplicantId }).IsUnique();
            
            modelBuilder.Entity<JobEcowasCompetence>().HasOne<Job>(jo => jo.Job).WithMany(ex => ex.JobEcowasCompetences).HasForeignKey(jo => jo.JobId).OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<JobEcowasCompetence>().HasIndex(jec => new { jec.CheckId, jec.JobId }).IsUnique();

            modelBuilder.Entity<JobLanguage>().HasOne<Job>(jo => jo.Job).WithMany(jo => jo.JobLanguages).HasForeignKey(jo => jo.JobId).OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<JobLanguage>().HasIndex(jl => new { jl.CheckId, jl.JobId }).IsUnique();

            modelBuilder.Entity<JobSkill>().HasOne<Job>(jo => jo.Job).WithMany(jo => jo.JobSkills).HasForeignKey(jo => jo.JobId).OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<JobSkill>().HasIndex(js => new { js.CheckId, js.JobId }).IsUnique();

            modelBuilder.Entity<JobSpecialRequirement>().HasOne<Job>(jo => jo.Job).WithMany(jo => jo.JobSpecialRequirements).HasForeignKey(jo => jo.JobId).OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<JobSpecialRequirement>().HasIndex(jsr => new { jsr.CheckId, jsr.JobId }).IsUnique();

        }
    }
}
