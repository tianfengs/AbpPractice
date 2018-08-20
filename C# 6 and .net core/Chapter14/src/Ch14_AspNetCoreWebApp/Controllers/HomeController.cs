using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ch14_AspNetCoreWebApp.Models;
using Microsoft.EntityFrameworkCore;
namespace Ch14_AspNetCoreWebApp.Controllers
{
    public class HomeController : Controller
    {
        private NorthwindContext db;
        public HomeController(NorthwindContext injectedContext)
        {
            db = injectedContext;
        }
        public IActionResult Index()
        {
            var vm = new HomeIndexViewModel
            {
                VisitorCount = new Random().Next(1, 1001),
                Products = db.Products.ToList()
            };
            return View(vm);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
        public IActionResult ProductDetail(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound("要查看产品的明细，必须给传入一个产品Id");
            }
            var vm = db.Products.SingleOrDefault(p => p.ProductId == id.Value);
            if (vm==null)
            {
                return NotFound($"没有找到产品Id={id.Value}的产品");
            }
            return View(vm);
        } 

        public IActionResult ProductsThatCostMoreThan(decimal? price)
        {
            if (!price.HasValue)
            {
                return NotFound("请输入价格！");
            }
            var vm = db.Products.Include(p => p.Category)
                .Include(p => p.Supplier)
                .Where(p => p.UnitPrice > price.Value).ToArray();
            if (vm==null)
            {
                return NotFound($"没有产品的价格超过{price.Value.ToString("C")}");
            }
            ViewData["MaxPrice"] = price.Value.ToString("C");
            return View(vm);
        }

    }
}
