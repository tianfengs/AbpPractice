using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Ch07_Exercise02
{
    class Program
    {
        static void Main(string[] args)
        {
            var re = new Rectangle { Height = 3, Width = 4 };
            var sq = new Square { Height = 3};
            var cir = new Circle { Radius = 2 };
            WriteLine($"长方形面积={re.Area}");
            WriteLine($"正方形面积={sq.Area}");
            WriteLine($"圆形面积={cir.Area}");
            Read();
        }
    }
}
