using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFormHttpModule
{
    public class MyHttpModule:IHttpModule
    {
        /// <summary>
        /// 释放所有的资源和数据库连接
        /// </summary>
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 当HttpApplication的实例创建时运行
        /// </summary>
        /// <param name="context"></param>
        public void Init(HttpApplication context)
        {
            context.BeginRequest += context_BeginRequest;
            context.EndRequest += context_EndRequest;
        }

        /// <summary>
        /// 在所有的其他页面生命周期事件结束之后运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void context_EndRequest(object sender, EventArgs e)
        {
            var app = sender as HttpApplication;
            app.Response.Write("页面所有的生命周期事件结束之后");
        }
        /// <summary>
        /// 页面处理请求之前运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void context_BeginRequest(object sender, EventArgs e)
        {
            var app = sender as HttpApplication;
            app.Response.Write("页面请求处理之前");
        }
    }
}