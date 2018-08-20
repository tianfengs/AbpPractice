using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace ABPMVCTest.Authorization
{
    public class ABPMVCTestAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //Common permissions
            var pages = context.GetPermissionOrNull(PermissionNames.Pages);
            if (pages == null)
            {
                pages = context.CreatePermission(PermissionNames.Pages, L("Pages"));
            }

            //Host permissions
            var tenants = pages.CreateChildPermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, ABPMVCTestConsts.LocalizationSourceName);
        }
    }
}
