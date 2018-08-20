using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace AuthenticationAndAuthorization.Controllers
{
    public class TestAuthorizationController : Controller
    {
        [Authorize]
        public async Task<IActionResult> Index1()
        {
            return  Content("Authorize");
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index2()
        {
            return Content("AllowAnonymous");
        }

        [Authorize(Roles ="Doctors,Nurses")]
        public async Task<IActionResult> Index3()
        {
            return Content("Doctors,Nurses Role Access!");
        }

        [Authorize(Roles = "Doctors")]
        public async Task<IActionResult> Index4()
        {
            return Content("Doctors Role Access Only!");
        }

        [Authorize(Policy = "DoctorsOnly")]
        public async Task<IActionResult> Index5()
        {
            return Content("Doctors Claim Access Only!");
        }
    }
}