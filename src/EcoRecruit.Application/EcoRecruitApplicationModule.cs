using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using EcoRecruit.Authorization;

namespace EcoRecruit
{
    [DependsOn(
        typeof(EcoRecruitCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class EcoRecruitApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<EcoRecruitAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(EcoRecruitApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
