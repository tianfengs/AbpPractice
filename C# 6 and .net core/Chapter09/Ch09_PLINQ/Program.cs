using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Diagnostics;

namespace Ch09_PLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("按下回车键开始");
            ReadLine();
            WriteLine("开始！！！");
            var watch = new Stopwatch();
            watch.Start();
            IEnumerable<int> numbers= Enumerable.Range(1, 200000000);
            //var squares = numbers.Select(n => n * 2).ToArray();
            var squares = numbers.AsParallel().Select(n => n * 2).ToArray();//并发查询
            watch.Stop();
            WriteLine($"共经历了{watch.ElapsedMilliseconds:#,##0}毫秒");
        }
    }
}
