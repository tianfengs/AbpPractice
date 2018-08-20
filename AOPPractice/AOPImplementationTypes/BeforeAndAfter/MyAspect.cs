using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Aspects;
namespace BeforeAndAfter
{
    [Serializable]
    public class MyAspect:OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            Console.WriteLine("Before");
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            Console.WriteLine("After");
        }
    }
}
