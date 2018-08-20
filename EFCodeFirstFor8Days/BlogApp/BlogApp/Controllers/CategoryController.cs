using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogAppDAL.Entities;
using BlogAppDAL.UoW;

namespace BlogApp.Controllers
{
    public class CategoryController : Controller
    {
        //
        // GET: /Category/

        public ActionResult Index()
        {
            using (var uow = new UnitOfWork())
            {
                var categories = uow.CategoryRepository.GetAll().ToList();
                return View(categories);
            }
        }

        //
        // GET: /Category/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Category/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Category/Create

        [HttpPost]
        public ActionResult Create(Category model)
        {
            try
            {
                using (var uow = new UnitOfWork())
                {
                    uow.CategoryRepository.Insert(model);
                    uow.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Category/Edit/5

        public ActionResult Edit(int id)
        {
            using (var uow=new UnitOfWork())
            {
                var category = uow.CategoryRepository.Get(c => c.Id == id);
                return View(category);
            }
        }

        //
        // POST: /Category/Edit/5

        [HttpPost]
        public ActionResult Edit(Category model)
        {
            try
            {
                using (var uow=new UnitOfWork())
                {
                    uow.CategoryRepository.Update(model);
                    uow.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                using (var uow=new UnitOfWork())
                {
                    var category = uow.CategoryRepository.Get(c => c.Id == id);
                    uow.CategoryRepository.Delete(category);
                    uow.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
