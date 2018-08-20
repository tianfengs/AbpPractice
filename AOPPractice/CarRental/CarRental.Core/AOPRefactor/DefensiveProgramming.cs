using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Aspects;

namespace CarRental.Core.AOPRefactor
{
    [Serializable]
    public class DefensiveProgramming:OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            var parameters = args.Method.GetParameters();//获取形参
            var arguments = args.Arguments;//获取实参
            for (int i = 0; i < arguments.Count; i++)
            {
                if (arguments[i]==null)
                {
                    throw new ArgumentNullException(parameters[i].Name);
                }
                if (arguments[i] is int&&(int)arguments[i]<=0)
                {
                    throw new ArgumentException("参数非法",parameters[i].Name);
                }
            }
        }
    }
}
