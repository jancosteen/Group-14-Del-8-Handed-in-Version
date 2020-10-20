using Abp.Modules;
using Abp.Reflection.Extensions;
using MDR_Angular.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace MDR_Angular.Web.Host.Startup
{
    [DependsOn(
       typeof(MDR_AngularWebCoreModule))]
    public class MDR_AngularWebHostModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MDR_AngularWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MDR_AngularWebHostModule).GetAssembly());
        }
    }
}
