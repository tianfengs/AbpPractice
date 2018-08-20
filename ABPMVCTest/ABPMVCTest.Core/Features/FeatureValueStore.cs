using Abp.Application.Features;
using ABPMVCTest.Authorization.Roles;
using ABPMVCTest.MultiTenancy;
using ABPMVCTest.Users;

namespace ABPMVCTest.Features
{
    public class FeatureValueStore : AbpFeatureValueStore<Tenant, Role, User>
    {
        public FeatureValueStore(TenantManager tenantManager)
            : base(tenantManager)
        {
        }
    }
}