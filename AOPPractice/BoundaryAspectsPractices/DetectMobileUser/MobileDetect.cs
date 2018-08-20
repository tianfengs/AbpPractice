using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DetectMobileUser
{
    public class MobileDetect
    {
        readonly HttpRequest _request;

        public MobileDetect(HttpContext context)
        {
            _request = context.Request;
        }

        public bool IsMobile()
        {
            return _request.Browser.IsMobileDevice&&(IsWindowsMobile()||IsAndroid()||IsApple());
        }
        /// <summary>
        /// 检测是否是Windows Mobile手机，本人在调试时发现，Windows 10 Mobile系统的UserAgent同时包含了下面的两个关键字
        /// </summary>
        /// <returns></returns>
        public bool IsWindowsMobile()
        {
            return _request.UserAgent.Contains("Windows Phone") && _request.UserAgent.Contains("Android");
        }

        public bool IsApple() 
        {
            return _request.UserAgent.Contains("iPhone") || _request.UserAgent.Contains("iPad");
        }

        public bool IsAndroid()
        {
            return _request.UserAgent.Contains("Android") && !_request.UserAgent.Contains("Windows Phone");
        }

    }
}