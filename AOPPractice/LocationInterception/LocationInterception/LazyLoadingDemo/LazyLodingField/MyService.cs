using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyLoadingDemo.LazyLodingField
{
    public class MyService:IMyService
    {
        public void DoSomething()
        {
            Console.WriteLine("{0}:正在处理一些业务...", DateTime.Now);
        }
    }
}
