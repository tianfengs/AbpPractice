using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch05Debug
{
    class Program
    {
        static double Add(double a, double b)
        {
            return a + b; // deliberate bug!
        }
        static void Main(string[] args)
        {
            double a = 4.5; // or use var
            double b = 2.5;
            double answer = Add(a, b);
            WriteLine($"{a} + {b} = {answer}");
            ReadLine(); // wait for user to press ENTER
        }
    }
}
