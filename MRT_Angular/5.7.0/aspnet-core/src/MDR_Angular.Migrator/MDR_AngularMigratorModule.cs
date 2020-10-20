using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.MicroKernel.Registration;
using MDR_Angular.Configuration;
using MDR_Angular.EntityFrameworkCore;
using MDR_Angular.Migrator.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace MDR_Angular.Migrator
{
    [DependsOn(typeof(MDR_AngularEntityFrameworkModule))]
    public class MDR_AngularMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public MDR_AngularMigratorModule(MDR_AngularEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(MDR_AngularMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                MDR_AngularConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus),
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MDR_AngularMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
