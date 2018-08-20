using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using  System.Text.Encodings.Web;
namespace PatientRecords.Controllers
{
    public class PatientController : Controller
    {
        public IActionResult Index()
        {
            //return HtmlEncoder.Default.Encode("id:"+id+",Name:"+name);
            return View();
        }

        public IActionResult Details(int id, string name = "Unknown")
        {
            ViewData["PatientId"] = id;
            ViewData["Name"] = name;

            return View();
        }
    }
}