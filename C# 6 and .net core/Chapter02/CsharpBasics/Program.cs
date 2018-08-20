using static System.Console;

namespace CsharpBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            var nick = "汪汪";
            WriteLine($"变量{nameof(nick)}的值是{nick}");
            WriteLine($"int使用了{sizeof(int)}个字节,范围是{int.MinValue}到{int.MaxValue}");
            WriteLine($"double使用了{sizeof(double)}个字节,范围是{double.MinValue}到{double.MaxValue:N0}");
            WriteLine($"decimal使用了{sizeof(decimal)}个字节,范围是{decimal.MinValue}到{decimal.MaxValue}");
            WriteLine($"long使用了{sizeof(long)}个字节,范围是{long.MinValue}到{long.MaxValue}");

            double a = 0.1;
            double b = 0.2;
            if (a+b==0.3)
            {
                WriteLine($"{a}+{b}=0.3");
            }
            else
            {
                WriteLine($"{a}+{b}!=0.3");
            }

            decimal a2 = 0.1M;
            decimal b2 = 0.2M;
            if (a2 + b2 == 0.3M)
            {
                WriteLine($"{a2}+{b2}=0.3");
            }
            else
            {
                WriteLine($"{a2}+{b2}!=0.3");
            }

            object name1 = "farb";
            dynamic name2 = "farb2";
            int length = ((string)name1).Length;//object类型必须强制转换
            int length2 = name2.Length;//没用智能提示，编译不报错，但运行时可能出错

            decimal cost = 2.5M;

            WriteLine($"价格：{cost:C}");
            Read();
        }
    }
}
