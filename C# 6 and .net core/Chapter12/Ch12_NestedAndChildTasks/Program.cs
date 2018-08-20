using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Console;

namespace Ch12_NestedAndChildTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            //嵌套任务和子任务
            var outer = Task.Factory.StartNew(() =>
            {
                WriteLine("Outer task starting...");
                var inner = Task.Factory.StartNew(() =>
                {
                    WriteLine("Inner task starting...");
                    Thread.Sleep(2000);
                    WriteLine("Inner task finished.");
                }, TaskCreationOptions.AttachedToParent);
            });
            outer.Wait();
            WriteLine("Outer task finished.");
            ReadLine();
        }
    }
}
