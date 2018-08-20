using Abp.Authorization.Roles;
using ABPMVCTest.MultiTenancy;
using ABPMVCTest.Users;

namespace ABPMVCTest.Authorization.Roles
{
    public class Role : AbpRole<Tenant, User>
    {

    }
}