using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MDR_Angular.EntityFrameworkCore;
using MDR_Angular.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace MDR_Angular.Web.Tests
{
    [DependsOn(
        typeof(MDR_AngularWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class MDR_AngularWebTestModule : AbpModule
    {
        public MDR_AngularWebTestModule(MDR_AngularEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MDR_AngularWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(MDR_AngularWebMvcModule).Assembly);
        }
    }
}