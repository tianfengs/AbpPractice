using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeforeAndAfter
{
    class Program
    {
        [MyAspect]
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
