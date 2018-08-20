using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace WeiBoWithDynamicProxy
{
    public class MyInterceptorAspect:IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("【DynamicProxy拦截器执行开始：{0}】",DateTime.Now);
            Console.WriteLine("【DynamicProxy拦截器】拦截到的方法传入的实参是："+invocation.Arguments.First());
            invocation.Proceed();
            Console.WriteLine("【DynamicProxy拦截器执行结束：{0}】",DateTime.Now);
        }
    }
}
