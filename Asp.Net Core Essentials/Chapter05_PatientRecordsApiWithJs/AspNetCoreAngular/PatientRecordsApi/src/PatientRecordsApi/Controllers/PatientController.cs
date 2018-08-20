using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PatientRecordsApi.Models;

namespace PatientRecordsApi.Controllers
{
    [Route("api/[controller]")]
    public class PatientController : Controller
    {
        public Patient[] Patients { get; set; }
        public PatientController()
        {
            Patients = new Patient[]
            {
                new Patient
                {
                    Id = 1,
                    Name = "John",
                    SocialSecurityNumber = "123550001"
                },
                new Patient
                {
                    Id = 2,
                    Name = "Jane",
                    SocialSecurityNumber = "123550002"
                },
                new Patient
                {
                    Id = 3,
                    Name = "Lisa",
                    SocialSecurityNumber = "123550003"
                }
           };
        }

        // GET api/Patient
        [HttpGet]
        public IEnumerable<Patient> Get()
        {
            return Patients;
        }

        // GET api/Patient/5
        [HttpGet("{id}")]
        public Patient Get(int id)
        {
            var patient = Patients.FirstOrDefault(p => p.Id == id);

            return patient;
        }

        // POST api/Patient
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/Patient/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
