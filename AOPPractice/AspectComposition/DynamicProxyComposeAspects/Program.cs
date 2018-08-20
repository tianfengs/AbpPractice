using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace DynamicProxyComposeAspects
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container(_ =>
            {
                _.For<IMyClass>()
                    .DecorateAllWith(
                        instance =>
                            (IMyClass)
                                DynamicProxyHelper.CreateInterfaceProxyWithTargetInterface(typeof(IMyClass), instance));
                _.For<IMyClass>().Use<MyClass>();
            });

            Read();
        }
    }
}
