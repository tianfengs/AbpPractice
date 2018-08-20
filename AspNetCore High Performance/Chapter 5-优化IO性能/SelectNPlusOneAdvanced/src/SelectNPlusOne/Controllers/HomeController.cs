﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using System.Data.SqlClient;
using SelectNPlusOne.Models;

namespace SelectNPlusOne.Controllers
{
    public class HomeController : Controller
    {
        private const string connectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=SelectNPlusOneTestDB-001;Integrated Security=True";
        /// <summary>
        /// 获取数据比较好的一种方式，本机耗时92.7291ms
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                var sql = @"select  bp.BlogPostId,bp.Title,COUNT(bpc.BlogPostCommentId) as CommentCount from BlogPost bp left join BlogPostComment bpc
                      on bp.BlogPostId=bpc.BlogPostId 
                      group by bp.BlogPostId,bp.Title 
                      order by CommentCount desc
                      offset @OffsetRows rows fetch next @LimitRows rows only; ";
                IEnumerable<BlogPost> blogs = await conn.QueryAsync<BlogPost>(sql, new
                {
                    OffsetRows = (pageNumber - 1) * pageSize,
                    LimitRows = pageSize
                });
                return View(blogs);
            }
        }
        /// <summary>
        /// 展示评论数最多的前10篇文章，耗时101.3103ms
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> TopTen()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                var sql = @"select top 10  bp.BlogPostId,bp.Title,COUNT(bpc.BlogPostCommentId) as CommentCount from BlogPost bp left join BlogPostComment bpc
                      on bp.BlogPostId=bpc.BlogPostId 
                      group by bp.BlogPostId,bp.Title 
                      order by CommentCount desc; ";
                IEnumerable<BlogPost> blogs = await conn.QueryAsync<BlogPost>(sql);
                return View("Index", blogs);
            }
        }

        /// <summary>
        /// 不太好的分页方式，耗时3907.1323ms
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<IActionResult> BadPaging(int pageNumber = 1, int pageSize = 10)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                var sql = @"select  bp.BlogPostId,bp.Title,COUNT(bpc.BlogPostCommentId) as CommentCount from BlogPost bp left join BlogPostComment bpc
                      on bp.BlogPostId=bpc.BlogPostId 
                      group by bp.BlogPostId,bp.Title; ";
                IEnumerable<BlogPost> blogs = await conn.QueryAsync<BlogPost>(sql);
                //分页发生在应用中而非数据库中
                return View("Index", blogs.OrderByDescending(b => b.CommentCount).Skip((pageNumber - 1) * pageSize).Take(pageSize));

            }
        }
        /// <summary>
        /// 低效的获取数据方式,本机耗时18848.3936ms
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> BadWay()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                var blogPosts = await conn.QueryAsync<BlogPost>("select * from BlogPost");
                var innerSql = @"select * from BlogPostComment where BlogPostId=@BlogPostId";
                foreach (var post in blogPosts)
                {
                    var comments = await conn.QueryAsync<BlogPostComment>(innerSql, new { BlogPostId = post.BlogPostId });
                    post.CommentCount = comments.Count();
                }
                return View("Index", blogPosts);
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertPost()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                var newPost = new BlogPost
                {
                    Title = "Insert Post",
                    Content = "Insert-Post-Content"
                };
                newPost.BlogPostId = await conn.ExecuteScalarAsync<int>(@"insert into BlogPost(Title,Content)
                    Output Inserted.BlogPostId values(@Title,@Content)", newPost);
            }
            return RedirectToAction("Index");
        }
        /// <summary>
        /// 分别插入3条博客
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Insert3Posts()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                var newPost = new BlogPost
                {
                    Title = "Insert 3 Posts",
                    Content = "Insert 3 Posts-Content"
                };
                var numberOfRows = await conn.ExecuteAsync(@"insert into BlogPost(Title,Content)
                    Output Inserted.BlogPostId values(@Title,@Content)", new[] { newPost, newPost, newPost });
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// 批量插入2条博客
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Insert2Posts()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                var newPost = new BlogPost
                {
                    Title = "Insert 2 Posts",
                    Content = "Insert-2Posts-Content"
                };
                var ids = await conn.QueryAsync<int>(@"insert into BlogPost(Title,Content)
                    Output Inserted.BlogPostId values(@Title1,@Content1),(@Title2,@Content2)", new
                {
                    Title1 = newPost.Title,
                    Content1 = newPost.Content,
                    Title2 = newPost.Title,
                    Content2 = newPost.Content,
                });
            }
            return RedirectToAction("Index");
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
    }
}
