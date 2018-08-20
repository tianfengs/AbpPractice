using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch06Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                WriteLine("请输入整数：");
                int n = int.Parse(ReadLine());
                var answer = Factorial(n);
                WriteLine($"结果是：{answer}");
            }
        }

        static int Factorial(int n)
        {
            if (n <= 1) return 1;
            return Factorial(n - 1) * n;
        }
    }
}
