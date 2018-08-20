using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace PostSharpUT
{
    public class MyInterceptor:IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Log.Write(invocation.Method.Name+"执行前");
            invocation.Proceed();
            Log.Write(invocation.Method.Name+"执行后");
        }
    }
}
