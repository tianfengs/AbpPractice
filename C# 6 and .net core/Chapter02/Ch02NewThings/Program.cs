using static System.Console;
using  System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch02NewThings
{
    class Program
    {
        static void Main(string[] args)
        {
            BackgroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), args[0], true);
            ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), args[1], true);
            WindowWidth = int.Parse(args[2]);
            WindowHeight = int.Parse(args[3]);
            WriteLine($"共输入{args.Length}个参数");
            Write("这些参数分别是：");
            foreach (var arg in args)
            {
                Write(arg+"\t");
            }

           
            Read();
        }
    }
}
