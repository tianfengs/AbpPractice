using PostSharp.Aspects;
using System;
using System.Reflection;

namespace AopInitialAndValidate
{
    [Serializable]
    public class MyLoggingAspect:OnMethodBoundaryAspect
    {
        private string _methodName = string.Empty;
        //public override void OnEntry(MethodExecutionArgs args)
        //{
        //    Console.WriteLine($"The method name is {args.Method.Name}");
        //}

        public override void OnEntry(MethodExecutionArgs args)
        {
            //这次直接使用私有字段而不是反射
            Console.WriteLine($"The method name is {_methodName}");
        }
        public override void CompileTimeInitialize(MethodBase method, AspectInfo aspectInfo)
        {
            _methodName = method.Name;//存储方法名称到私有字段
        }
    }
}
