using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Aspects;

namespace PostSharpLocationInterceptionDemo
{
    [Serializable]
    public class MyMethodAspect:MethodInterceptionAspect
    {
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            Console.WriteLine("这条语句来自自定义方法拦截切面");
            args.Proceed();
        }
    }
}
