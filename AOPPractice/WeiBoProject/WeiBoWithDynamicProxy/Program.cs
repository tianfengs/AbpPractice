using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace WeiBoWithDynamicProxy
{
    class Program
    {
        static void Main(string[] args)
        {
            var proxyGenerator=new ProxyGenerator();//创建一个代理生成器
            //下面这行代码是为要拦截的类创建代理，第一个泛型参数就是要拦截的类，第二个参数是自定义的切面
             var weiboService=proxyGenerator.CreateClassProxy<WeiBoClient>(new MyInterceptorAspect());
            weiboService.Send("hello");
            Console.WriteLine(weiboService);
            Console.WriteLine();
            Console.Read();
        }
    }
}
