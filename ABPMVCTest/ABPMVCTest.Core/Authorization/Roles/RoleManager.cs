using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Runtime.Caching;
using Abp.Zero.Configuration;
using ABPMVCTest.MultiTenancy;
using ABPMVCTest.Users;

namespace ABPMVCTest.Authorization.Roles
{
    public class RoleManager : AbpRoleManager<Tenant, Role, User>
    {
        public RoleManager(
            RoleStore store,
            IPermissionManager permissionManager,
            IRoleManagementConfig roleManagementConfig,
            ICacheManager cacheManager)
            : base(
                store,
                permissionManager,
                roleManagementConfig,
                cacheManager)
        {
        }
    }
}