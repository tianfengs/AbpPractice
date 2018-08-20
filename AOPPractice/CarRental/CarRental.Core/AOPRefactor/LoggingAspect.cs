using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Core.Entities;
using PostSharp.Aspects;

namespace CarRental.Core.AOPRefactor
{
    [Serializable]
    public class LoggingAspect:OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            Console.WriteLine("{0}:{1}",args.Method.Name,DateTime.Now);
            foreach (var argument in args.Arguments)//遍历方法的参数
            {
                if (argument.GetType()==typeof(RentalAgreement))
                {
                    Console.WriteLine("Customer:{0}", ((RentalAgreement)argument).Customer.Id);
                    Console.WriteLine("Vehicle:{0}", ((RentalAgreement)argument).Vehicle.Id);
                }
                if (argument.GetType()==typeof(Invoice))
                {
                    Console.WriteLine("Invoice:{0}",((Invoice)argument).Id);
                }
            }
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            Console.WriteLine("{0} complete:{1}",args.Method.Name,DateTime.Now);
        }
    }
}
