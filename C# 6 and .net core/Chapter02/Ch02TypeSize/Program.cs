using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch02TypeSize
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintDash(95);
            WriteLine("{0,-10}{1,-15}{2,35}{3,35}","Type","Bytes of Memory","Min","Max");
            PrintDash(95);
            WriteLine("{0,-10}{1,-15}{2,35}{3,35}", "sbyte", sizeof(sbyte), sbyte.MinValue, sbyte.MaxValue);
            WriteLine("{0,-10}{1,-15}{2,35}{3,35}", "byte", sizeof(byte), byte.MinValue, byte.MaxValue);
            WriteLine("{0,-10}{1,-15}{2,35}{3,35}", "short", sizeof(short), short.MinValue, short.MaxValue);
            WriteLine("{0,-10}{1,-15}{2,35}{3,35}", "ushort", sizeof(ushort), ushort.MinValue, ushort.MaxValue);
            WriteLine("{0,-10}{1,-15}{2,35}{3,35}", "int", sizeof(int), int.MinValue, int.MaxValue);
            WriteLine("{0,-10}{1,-15}{2,35}{3,35}", "uint", sizeof(uint), uint.MinValue, uint.MaxValue);
            WriteLine("{0,-10}{1,-15}{2,35}{3,35}", "long", sizeof(long), long.MinValue, long.MaxValue);
            WriteLine("{0,-10}{1,-15}{2,35}{3,35}", "ulong", sizeof(ulong), ulong.MinValue, ulong.MaxValue);
            WriteLine("{0,-10}{1,-15}{2,35}{3,35}", "float", sizeof(float), float.MinValue, float.MaxValue);
            WriteLine("{0,-10}{1,-15}{2,35}{3,35}", "double", sizeof(double), double.MinValue, double.MaxValue);
            WriteLine("{0,-10}{1,-15}{2,35}{3,35}", "decimal", sizeof(decimal), decimal.MinValue, decimal.MaxValue);


            CancelKeyPress += Program_CancelKeyPress;
            Read();
        }

        private static void Program_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            WriteLine("您终止了程序运行");
            Read();
        }

        static void PrintDash(int length)
        {
            for (int i = 0; i < length; i++)
            {
                Write("-");
                if (i==length-1)
                {
                    WriteLine();
                }
            }
        }
    }
}
