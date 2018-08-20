using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using ABPMVCTest.Authorization;
using ABPMVCTest.MultiTenancy;

namespace ABPMVCTest.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Tenants)]
    public class TenantsController : ABPMVCTestControllerBase
    {
        private readonly ITenantAppService _tenantAppService;

        public TenantsController(ITenantAppService tenantAppService)
        {
            _tenantAppService = tenantAppService;
        }

        public ActionResult Index()
        {
            var output = _tenantAppService.GetTenants();
            return View(output);
        }
    }
}