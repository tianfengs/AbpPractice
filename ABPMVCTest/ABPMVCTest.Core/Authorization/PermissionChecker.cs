using Abp.Authorization;
using ABPMVCTest.Authorization.Roles;
using ABPMVCTest.MultiTenancy;
using ABPMVCTest.Users;

namespace ABPMVCTest.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
