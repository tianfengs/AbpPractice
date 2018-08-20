using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostSharpLocationInterceptionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //var test=new TestClass();
            //test.TestProperty = "测试属性";

            //var test2=new TestClass2();
            //test2.TestProperty = "位置拦截测试";
            //Console.WriteLine(test2.TestProperty);

            var lazy = new Lazy<SlowConstructor>(()=>new SlowConstructor());
            Console.Read();
        }
    }
}
