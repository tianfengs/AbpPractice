using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using ABPMVCTest.Authorization.Roles;
using ABPMVCTest.Editions;
using ABPMVCTest.Users;

namespace ABPMVCTest.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, Role, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager) 
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager
            )
        {
        }
    }
}