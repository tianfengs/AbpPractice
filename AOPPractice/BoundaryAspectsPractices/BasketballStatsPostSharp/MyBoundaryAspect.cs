using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Aspects;

namespace BasketballStatsPostSharp
{
    [Serializable]
    public class MyBoundaryAspect : OnMethodBoundaryAspect
    {
        private readonly Guid _sharedState;//使用一个全局变量共享方法之间的信息

        public MyBoundaryAspect()
        {
            // _sharedState = Guid.NewGuid();
        }
        public override void OnEntry(MethodExecutionArgs args)
        {
            //_sharedState = "123";//边界方法运行之前，设置一个值
            args.MethodExecutionTag = Guid.NewGuid();
            Console.WriteLine("方法{0}执行前，该方法生成的Guid={1}", args.Method.Name, args.MethodExecutionTag);
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            Console.WriteLine("方法{0}执行完成！", args.Method.Name);
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            //Console.WriteLine("方法{0}执行后,_sharedState={1}", args.Method.Name,_sharedState);//边界方法运行之后该值不变
            Console.WriteLine("方法{0}执行后，该方法生成的Guid={1}", args.Method.Name, args.MethodExecutionTag);
        }
    }


    public class MyIntercepor : MethodInterceptionAspect
    {
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            try
            {
                args.Proceed();//在边界切面中，这行代码是隐式执行的
            }
            finally //C#中的finally指的是，无论try中发生了什么，代码块都会执行
            {
                Console.WriteLine("方法{0}执行完成！", args.Method.Name);
            }
        }
    }
}
