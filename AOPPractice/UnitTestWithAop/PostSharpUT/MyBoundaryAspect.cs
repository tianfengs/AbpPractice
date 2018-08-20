using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Aspects;
using PostSharpUT;

namespace PostSharpUT
{
    [Serializable]
    public class MyBoundaryAspect:OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
           Log.Write("Before:"+args.Method.Name);
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            Log.Write("After:" + args.Method.Name);
        }
    }
}
