using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiBoWithDynamicProxy
{
   public  class WeiBoClient
    {
       public virtual void Send(string msg)
       {
           Console.WriteLine("【微博客户端】正在发送消息："+msg);
       }
    }
}
