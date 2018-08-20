using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Core.Services.Common;
using PostSharp.Aspects;

namespace CarRental.Core.AOPRefactor
{
    [Serializable]
    public class MyExceptionAspect:OnExceptionAspect
    {
        public override void OnException(MethodExecutionArgs args)
        {
            if (ExceptionHelper.Handle(args.Exception))
            {
               args.FlowBehavior=FlowBehavior.Continue;
            }
        }
    }
}
