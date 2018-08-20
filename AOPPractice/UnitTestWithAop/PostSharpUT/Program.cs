using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostSharpUT.Complex;
using StructureMap;

namespace PostSharpUT
{
    class Program
    {
        static void Main(string[] args)
        {
            ObjectFactory.Initialize(x =>
            {
                x.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });
            });

            var myObj = ObjectFactory.GetInstance<IServiceOne>();
            myObj.DoWorkOne();
            Console.Read();
        }
    }
}
