using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WeiboWindow
{
    public class WeiboService
    {
        public string GetMessage()
        {
            Thread.Sleep(3000);//模拟一个缓慢的web服务
            return "消息来自" + DateTime.Now;
        }
    }
}
