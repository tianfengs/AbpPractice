using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DetectMobileUser
{
    public class DetectMobileModule:IHttpModule
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += context_BeginRequest;
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            //如果请求中的Cookie包含NoThanks键或者上一次请求来自下载插入页或者当前请求就是下载插入页，那么直接返回
            if (ExistNoThanksCookie()||ComingFromMobileInterstitial()||OnMobileInterstitial())
            {
                return;
            }
            var context = HttpContext.Current;
            //使用当前上下文对象创建一个MobileDetect对象
            var mobileDetect=new MobileDetect(context);
            if (mobileDetect.IsMobile())
            {
                //如果用户拒绝下载APP，那么我们需要将他跳转回之前访问的页面
                var url = context.Request.RawUrl;
                var encodeUrl = HttpUtility.UrlEncode(url);
                //重定向到下载插入页，并带上returnUrl，以防用户需要返回到之前的页面
                context.Response.Redirect("MobileInterstitial.aspx?returnUrl=" + encodeUrl);
            }
        }
        /// <summary>
        /// 检查当前请求的前一次请求是否是来自下载插入页
        /// </summary>
        /// <returns></returns>
        bool ComingFromMobileInterstitial()
        {
            var request = HttpContext.Current.Request;
            if (request.UrlReferrer==null)
            {
                return false;
            }
            return request.UrlReferrer.AbsoluteUri.Contains("MobileInterstitial.aspx");
        }
        /// <summary>
        /// 判断当前请求是不是包含插入页文件
        /// </summary>
        /// <returns></returns>
        bool OnMobileInterstitial()
        {
            var request = HttpContext.Current.Request;
            return request.RawUrl.Contains("MobileInterstitial.aspx");
        }

        bool ExistNoThanksCookie()
        {
            return HttpContext.Current.Request.Cookies.Get("NoThanks") != null;
        }
    }
}