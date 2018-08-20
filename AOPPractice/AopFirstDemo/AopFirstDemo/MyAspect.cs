using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Aspects;

namespace AopFirstDemo
{
    [Serializable]
    public class MyAspect:OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            Console.WriteLine("方法执行前");
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            Console.WriteLine("方法执行后");
        }
    }
}
