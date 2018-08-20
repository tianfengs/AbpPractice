using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using AspNetMvcCacheDemo.Models;
using AspNetMvcCacheDemo.Service;

namespace AspNetMvcCacheDemo.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Value()
        {
            ViewData["Cache"]= DisplayCache();//显示缓存内容
            //制造商数据
            var makes = new SelectList(new List<SelectListItem>
            {
                new SelectListItem{Text = "法拉利",Value = "Ferrari",Selected = true},
                new SelectListItem{Text = "劳斯莱斯",Value = "Rolls-Royce"},
                new SelectListItem{Text = "迈巴赫",Value = "Maybach"}
            },"Value","Text");
            //年份数据
            var years=new SelectList(new List<SelectListItem>
            {
                new SelectListItem{Text = "2014年",Value = "2014"},
                new SelectListItem{Text = "2015年",Value = "2015"},
                new SelectListItem{Text = "2016年",Value = "2016",Selected = true}
            },"Value","Text");
            //条件数据
            var conditions=new SelectList(new List<SelectListItem>
            {
                new SelectListItem{Text = "经济型",Value = "poor",Selected = true},
                new SelectListItem{Text = "舒适型",Value = "comfort"},
                new SelectListItem{Text = "豪华型",Value = "best"}
            },"Value","Text");
            ViewData["makes"] = makes;
            ViewData["years"] = years;
            ViewData["conditions"] = conditions;
            return View();
        }

        [HttpPost]
        public ActionResult ValuePost(FormCollection collection)
        {
            var years = Convert.ToInt32(Request.Form.Get("years"));
            var makes = Request.Form.Get("makes");
            var conditions = Request.Form.Get("conditions");
            //第二种方式获取form表单的值
            //var years2 = Convert.ToInt32(collection.Get("years"));
            //var makes2 = collection.Get("makes");
            //var conditions2 = collection.Get("conditions");

            var carValueService=new CarValueService();
            //第一种方式获取汽车价格，不具有健壮性，故不采用
            //var value = carValueService.GetValue(years, makes, conditions);
            var value = carValueService.GetValueBetter(new CarValueArgs
            {
                Condition = conditions,Make = makes,Year = years
            });
            return Content(value.ToString("c"));
        }

        /// <summary>
        /// 显示缓存内容
        /// </summary>
        /// <returns></returns>
        private List<string> DisplayCache()
        {
            var cacheList=new List<string>();
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //Response.Cache.SetExpires(DateTime.Now.AddYears(-2));
            //ClearAllCache();
            foreach (DictionaryEntry cache in HttpContext.Cache)
            {
                cacheList.Add(string.Format("{0}-{1}",cache.Key,cache.Value));
            }
            if (!cacheList.Any())
            {
                cacheList.Add("None");
            }
            return cacheList;
        }
        /// <summary>
        /// 清空所有缓存
        /// </summary>
        private void ClearAllCache()
        {
            foreach (DictionaryEntry entry in HttpContext.Cache)
            {
                HttpContext.Cache.Remove((string)entry.Key);
            }
        }

    }
}
