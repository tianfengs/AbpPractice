using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace AuthenticationAndAuthorization.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    public class TestCorsController : Controller
    {
        [EnableCors("AllowSpecificOrigin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}