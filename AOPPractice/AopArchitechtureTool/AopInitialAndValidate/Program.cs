using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace AopInitialAndValidate
{
    class Program
    {
        static void Main(string[] args)
        {
            var mm = new MyClass();
            mm.MyMethod();
            Read();
        }
    }

    class MyClass
    {
        [MyLoggingAspect]
        public void MyMethod()
        {
            WriteLine("Now in MyMethod...");
        }
    }
}
