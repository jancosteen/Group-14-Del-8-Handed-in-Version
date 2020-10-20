using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using MDR_Angular.Authorization.Users;
using MDR_Angular.Editions;

namespace MDR_Angular.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository,
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository,
            EditionManager editionManager,
            IAbpZeroFeatureValueStore featureValueStore)
            : base(
                tenantRepository,
                tenantFeatureRepository,
                editionManager,
                featureValueStore)
        {
        }
    }
}
