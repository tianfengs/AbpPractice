using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DetectMobileUser
{
    public partial class MobileInterstitial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// “不，谢谢”的按钮点击事件，用户点击了该按钮之后，需要将用户导向之前访问的url
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnThanks_Click(object sender, EventArgs e)
        {
            //用户点击拒绝下载按钮之后，设置一个cookie，并根据自己的情况设置一个有效期，这里为了演示，设置为2分钟
            var cookie=new HttpCookie("NoThanks","yes");
            cookie.Expires = DateTime.Now.AddMinutes(2);
            Response.Cookies.Add(cookie);
            //取到上一次请求的url
            var url = Request.QueryString.Get("returnUrl");
            Response.Redirect(HttpUtility.UrlDecode(url));
        }
        /// <summary>
        /// 点击下载按钮之后，跳转到相应的应用市场
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDownload_Click(object sender, EventArgs e)
        {
            var mobileDetect=new MobileDetect(Context);
            if (mobileDetect.IsAndroid())
            {
                Response.Redirect("http://s1.music.126.net/download/android/CloudMusic_official_3.6.0.143673.apk");
            }
            if (mobileDetect.IsApple())
            {
                Response.Redirect("https://itunes.apple.com/app/id590338362");
            }
            if (mobileDetect.IsWindowsMobile())
            {
                Response.Redirect("https://www.microsoft.com/store/apps/9nblggh6g0jf");
            }
        }
    }
}