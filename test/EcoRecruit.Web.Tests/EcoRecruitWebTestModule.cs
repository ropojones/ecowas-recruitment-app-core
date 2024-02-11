using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using EcoRecruit.EntityFrameworkCore;
using EcoRecruit.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace EcoRecruit.Web.Tests
{
    [DependsOn(
        typeof(EcoRecruitWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class EcoRecruitWebTestModule : AbpModule
    {
        public EcoRecruitWebTestModule(EcoRecruitEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(EcoRecruitWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(EcoRecruitWebMvcModule).Assembly);
        }
    }
}