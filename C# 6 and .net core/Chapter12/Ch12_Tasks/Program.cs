using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Diagnostics;
using System.Threading;

namespace Ch12_Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = Stopwatch.StartNew();
            //同步运行3个方法
            //WriteLine("Running methods synchronously on one thread.");
            //MethodA();
            //MethodB();
            //MethodC();
            //WriteLine($"{timer.ElapsedMilliseconds:#,##0}ms elapsed.");//6,022ms

            //异步运行上面的三个方法
            //WriteLine("Running methods asynchronously on one thread.");
            //var task1 = new Task(MethodA);
            //task1.Start();
            //var task2 = Task.Factory.StartNew(MethodB);
            //var task3 = Task.Run(new Action(MethodC));
            //Task[] taskArr = { task1, task2, task3 };
            //Task.WaitAll(taskArr);
            //WriteLine($"{timer.ElapsedMilliseconds:#,##0}ms elapsed.");//3,008ms

            //延续任务：使用前一个任务的结果作为延续任务的输入
            WriteLine("Passing the result of one task as an input into another.");

            var taskCallWebServiceAndThenStoredProcedure =
                Task.Factory.StartNew(CallWebService)
                .ContinueWith(preTask => CallStoredProcedure(preTask.Result));
            WriteLine($"{taskCallWebServiceAndThenStoredProcedure.Result}");
            WriteLine("Press ENTER to end.");
            ReadLine();
        }

        static void MethodA()
        {
            WriteLine("Starting Method A...");
            Thread.Sleep(3000); // 模拟3秒的运行时间
            WriteLine("Finished Method A.");
        }
        static void MethodB()
        {
            WriteLine("Starting Method B...");
            Thread.Sleep(2000); // 模拟2秒的运行时间
            WriteLine("Finished Method B.");
        }
        static void MethodC()
        {
            WriteLine("Starting Method C...");
            Thread.Sleep(1000); // 模拟1秒的运行时间
            WriteLine("Finished Method C.");
        }

        static decimal CallWebService()
        {
            WriteLine("Starting call to web service...");
            Thread.Sleep((new Random()).Next(2000, 4000));
            WriteLine("Finished call to web service.");
            return 89.99M;
        }
        static string CallStoredProcedure(decimal amount)
        {
            WriteLine("Starting call to stored procedure...");
            Thread.Sleep((new Random()).Next(2000, 4000));
            WriteLine("Finished call to stored procedure.");
            return $"12 products cost more than {amount:C}.";
        }
    }
}
