using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ABPMVCTest.Web.Controllers;

namespace ABPMVCTest.Web.Areas.Mpa.Controllers
{
    public class HomeController : ABPMVCTestControllerBase
    {
        // GET: Mpa/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}