using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogApp.Models;
using BlogAppDAL.Entities;
using BlogAppDAL.UoW;

namespace BlogApp.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            using (var uow = new UnitOfWork())
            {
                var blogs = uow.BlogRepository.GetAll().Include(b => b.Category).Include(b => b.User).ToList();
                return View(blogs);
            }
        }

        // GET: Blog/Details/5
        public ActionResult Details(int id)
        {
            using (var uow = new UnitOfWork())
            {
                var blog = uow.BlogRepository.Get(b => b.Id == id);
                var blogDetailViewModel=new BlogDetailViewModel
                {
                    AuthorName = blog.User.UserName,
                    Body = blog.Body,
                    CreationTime = blog.CreationTime,
                    Id = blog.Id,
                    Title = blog.Title,
                    UpdateTime = blog.UpdateTime,
                    CategoryName = blog.Category.CategoryName
                };
                List<CommentViewModel> commentList= blog.Comments.Select(comment => new CommentViewModel
                {
                    PosterName = comment.User.UserName, Message = comment.Body,
                    CreationTime = comment.CreationTime,Id = comment.Id
                }).ToList();

                ViewData["Comments"] = commentList;
                return View(blogDetailViewModel);
            }
        }

        // GET: Blog/Create
        public ActionResult Create()
        {
            using (var uow = new UnitOfWork())
            {
                var categories = uow.CategoryRepository.GetAll().ToList();
                ViewData["categories"] = new SelectList(categories, "Id", "CategoryName");
            }
            return View();
        }

        // POST: Blog/Create
        [HttpPost]
        public ActionResult Create(Blog blog)
        {
            try
            {
                using (var uow = new UnitOfWork())
                {
                    blog.CategoryId = Convert.ToInt32(Request.Form.Get("CategoryId"));
                    blog.CreationTime = DateTime.Now;
                    blog.UpdateTime = DateTime.Now;
                    //blog.AuthorId = uow.UserRepository.Get(u => u.UserName == User.Identity.Name).Id;//以后加入Identity技术时使用
                    blog.AuthorId = 2;
                    uow.BlogRepository.Insert(blog);
                    uow.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Blog/Edit/5
        public ActionResult Edit(int id)
        {
            using (var uow = new UnitOfWork())
            {
                var categories = uow.CategoryRepository.GetAll().ToList();
                ViewData["categories"] = new SelectList(categories, "Id", "CategoryName");
                var blog = uow.BlogRepository.Get(b => b.Id == id);
                return View(blog);
            }
        }

        // POST: Blog/Edit/5
        [HttpPost]
        public ActionResult Edit(Blog blog)
        {
            try
            {
                using (var uow = new UnitOfWork())
                {
                    blog.UpdateTime = DateTime.Now;
                    uow.BlogRepository.Update(blog);
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
                using (var uow = new UnitOfWork())
                {
                    var blog = uow.BlogRepository.Get(b => b.Id == id);
                    uow.BlogRepository.Delete(blog);
                    uow.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
