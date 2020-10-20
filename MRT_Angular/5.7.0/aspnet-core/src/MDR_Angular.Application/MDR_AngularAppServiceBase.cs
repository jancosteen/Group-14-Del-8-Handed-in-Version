using Abp.Application.Services;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using MDR_Angular.Authorization.Users;
using MDR_Angular.MultiTenancy;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace MDR_Angular
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class MDR_AngularAppServiceBase : ApplicationService
    {
        public TenantManager TenantManager { get; set; }

        public UserManager UserManager { get; set; }

        protected MDR_AngularAppServiceBase()
        {
            LocalizationSourceName = MDR_AngularConsts.LocalizationSourceName;
        }

        protected virtual async Task<User> GetCurrentUserAsync()
        {
            var user = await UserManager.FindByIdAsync(AbpSession.GetUserId().ToString());
            if (user == null)
            {
                throw new Exception("There is no current user!");
            }

            return user;
        }

        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
