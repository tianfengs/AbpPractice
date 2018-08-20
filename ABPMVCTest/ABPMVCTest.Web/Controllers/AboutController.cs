using System.Web.Mvc;

namespace ABPMVCTest.Web.Controllers
{
    public class AboutController : ABPMVCTestControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}