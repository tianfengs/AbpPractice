using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Aspects;

namespace WeiBoWithPostSharp
{
    [Serializable]
    public class MyInterceptorAspect:MethodInterceptionAspect
    {
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            Console.WriteLine("【拦截器：】，方法执行前拦截到的信息是："+args.Arguments.First());//打印出拦截的方法第一个实参
            args.Proceed();//Proceed()方法表示继续执行拦截的方法
            Console.WriteLine("【拦截器：】，方法已在成功{0}执行",DateTime.Now);//被拦截方法执行完成之后执行
        }
    }
}
