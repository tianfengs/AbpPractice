using static System.Console;
using static System.Convert;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;

namespace Ch03ControlFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] names = { "Adam", "Barry", "Charlie" };
            //foreach (string name in names)
            //{
            //    WriteLine($"{name} has {name.Length} characters.");
            //}
            double a = 9.8;
            int b = (int)a;
            int c = ToInt32(a);
            WriteLine($"a={a},b={b},c={c}");


            //double i = 9.49;
            double j = 9.5;
            double k = 10.49;
            double l = 10.5;
            //WriteLine($"i is {i}, ToInt(i) is {ToInt32(i)}");
            WriteLine($"j is {j}, ToInt(j) is {ToInt32(j)}");
            WriteLine($"k is {k}, ToInt(k) is {ToInt32(k)}");
            WriteLine($"l is {l}, ToInt(l) is {ToInt32(l)}");//C#中的四舍五入稍微不一样【银行家四舍五入法】，当小数点后一位>=5，并且整数部分是奇数时才进位，否则舍去
            unchecked
            {
               // int m = 9876543210;
               // Write(m);
            }

            //WriteLine(1.0 / 0);//无穷大
            //int max = 500;
            //checked
            //{
            //    for (byte i = 0; i < max; i++)
            //    {
            //        WriteLine(i);

            //    }

            //}
            //WriteLine(m/0);//System.DivideByZeroException

            WriteLine("请输入1-255的数字：");
            string str1 = ReadLine();
            WriteLine("请再输入1-255的数字：");
            string str2 = ReadLine();

            try
            {
                byte n1 = byte.Parse(str1);
                byte n2 = byte.Parse(str2);
                    WriteLine($"{n2}/{n1}={n2/n1}");
            }
            catch (FormatException ex)
            {
                WriteLine(ex.GetType()+"格式不正确！");
            }
            catch(OverflowException ex)
            {
                WriteLine("超出范围了！");
            }
            catch (System.Exception e)
            {
                WriteLine(e.GetType() + e.Message);
            }
            SecureString
            Read();
        }
    }
}
