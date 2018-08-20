using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogApp.Models;
using BlogAppDAL.UoW;

namespace BlogApp.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index(int page=0)
        {
            using (var uow=new UnitOfWork())
            {
                var blogs = uow.BlogRepository.GetAll()
                    .Include(b=>b.User).Include(b=>b.Comments)
                    .OrderByDescending(b => b.CreationTime)
                    .Skip(page*10)
                    .Take(10);

                var blogSummaryList = blogs.Select(b => new BlogViewModel
                {
                    AuthorName = b.User.UserName,
                    CommentsCount = b.Comments.Count,
                    CreationTime = b.CreationTime,
                    Id = b.Id,
                    Overview = b.Body.Length>200?b.Body.Substring(0,200):b.Body,
                    Title = b.Title,
                    UpdateTime = b.UpdateTime
                }).ToList();

                return View(blogSummaryList);
            }
        }

    }
}
