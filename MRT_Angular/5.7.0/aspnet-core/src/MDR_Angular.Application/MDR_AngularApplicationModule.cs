using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MDR_Angular.Authorization;

namespace MDR_Angular
{
    [DependsOn(
        typeof(MDR_AngularCoreModule),
        typeof(AbpAutoMapperModule))]
    public class MDR_AngularApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<MDR_AngularAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(MDR_AngularApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
