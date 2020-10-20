using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace MDR_Angular.Controllers
{
    public abstract class MDR_AngularControllerBase : AbpController
    {
        protected MDR_AngularControllerBase()
        {
            LocalizationSourceName = MDR_AngularConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
