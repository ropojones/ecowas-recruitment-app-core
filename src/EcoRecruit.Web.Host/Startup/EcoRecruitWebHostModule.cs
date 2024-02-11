using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using EcoRecruit.Configuration;

namespace EcoRecruit.Web.Host.Startup
{
    [DependsOn(
       typeof(EcoRecruitWebCoreModule))]
    public class EcoRecruitWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public EcoRecruitWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(EcoRecruitWebHostModule).GetAssembly());
        }
    }
}
