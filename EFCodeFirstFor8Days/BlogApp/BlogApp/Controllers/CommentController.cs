using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogAppDAL.Entities;
using BlogAppDAL.UoW;
using Newtonsoft.Json;

namespace BlogApp.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment
        public PartialViewResult Index(IEnumerable<Comment> comments)
        {

            return PartialView();
        }

        // GET: Comment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Comment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comment/Create
        [HttpPost]
        public ContentResult Create(Comment comment)
        {
            try
            {
                using (var uow = new UnitOfWork())
                {
                    comment.PosterId = 2;//这里直接写入Id，本该写入当前评论者的Id
                    comment.CreationTime = DateTime.Now;
                    uow.CommentRepository.Insert(comment);
                    uow.SaveChanges();
                }
                return Content(JsonConvert.SerializeObject(new
                {
                    PosterName = "Farb",//本该是当前评论者的用户名
                    CreationTime = comment.CreationTime, Body = comment.Body
                }));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: Comment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Comment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Comment/Delete/5
        public ContentResult Delete(int id)
        {
            try
            {
                using (var uow=new UnitOfWork())
                {
                    var comment= uow.CommentRepository.Get(c => c.Id == id);
                    uow.CommentRepository.Delete(comment);
                    uow.SaveChanges();
                }

                return Content("ok");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

    }
}
