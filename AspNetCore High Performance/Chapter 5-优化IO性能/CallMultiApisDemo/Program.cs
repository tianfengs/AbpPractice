using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CallMultiApisDemo
{
    public class Program
    {
        /// <summary>
        /// 从这个例子可以看出，并行异步调用比同步更加有效，而且如果有多个task，
        /// 先执行耗时短的task
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var runs = 20;
            Console.WriteLine($"Benchmarking over an average of {runs} runs");

            var clock1 = Stopwatch.StartNew();
            for (int i = 0; i < runs; i++)
            {
                CallApiA().Wait();
                CallApiB().Wait();
            }
            clock1.Stop();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"A then B mean elapsed time: {clock1.ElapsedMilliseconds / runs} ms");

            var clock2 = Stopwatch.StartNew();
            for (int i = 0; i < runs; i++)
            {
                Task.WaitAll(CallApiA(), CallApiB());
            }
            clock2.Stop();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"A and B mean elapsed time: {clock2.ElapsedMilliseconds / runs} ms");

            var clock3 = Stopwatch.StartNew();
            for (int i = 0; i < runs; i++)
            {
                Task.WaitAll(CallApiB(), CallApiA());
            }
            clock3.Stop();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"B and A mean elapsed time: {clock3.ElapsedMilliseconds / runs} ms");

            Console.ResetColor();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }

        public static async Task CallApiA()
        {
            Thread.Sleep(10);
            await Task.Delay(100);
        }
        public static async Task CallApiB()
        {
            Thread.Sleep(10);
            await Task.Delay(200);
        }
    }
}
