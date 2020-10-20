using Abp.MultiTenancy;
using MDR_Angular.Authorization.Users;

namespace MDR_Angular.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
