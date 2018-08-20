using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ch14_AspNetCoreWebApp.Models;
// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Ch14_AspNetCoreWebApp.Controllers
{
    [Route("api/[controller]")]
    public class ShippersController : Controller
    {
        private NorthwindContext db;
        public ShippersController(NorthwindContext injectedContext)
        {
            db = injectedContext;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Shippers> GetShippers()
        {
            return db.Shippers.ToArray();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IEnumerable<Shippers> GetGetShipper(int id)
        {
            return db.Shippers.Where(s=>s.ShipperId==id).ToArray();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
