using System;
using AopFirstDemo.PostSharpTutorials;

namespace AopFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new MyClass();
            obj.MyMehtod();

            //var customer=new CustomerForEditing();
            //customer.Save("Farb","guo");

            Console.Read();
        }
    }

    class MyClass
    {
        [MyAspect]
        public void MyMehtod()
        {
            Console.WriteLine("Hello,AOP!");
        }
    }
}
