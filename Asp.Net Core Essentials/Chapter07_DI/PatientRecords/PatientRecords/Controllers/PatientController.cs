using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PatientRecords.Services;

namespace PatientRecords.Controllers
{
    public class PatientController : Controller
    {
        public IAppointService AppointService { get; set; }
        public PatientController(IAppointService appointService)
        {
            AppointService = appointService;
        }
        public string ProcessAppointment()
        {
            bool isSuccess = AppointService.ScheduleAppoint();
            if (isSuccess)
                return "Success!";
            else
                return "Failed...";
        }
        public IActionResult ActionInject([FromServices]IAppointService appointService)
        {
            ViewData["Message"] = "Scheduled: " + appointService.ScheduleAppoint();
            return View();
        }
    }
}