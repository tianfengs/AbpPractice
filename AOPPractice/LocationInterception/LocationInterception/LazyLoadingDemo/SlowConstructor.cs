using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LazyLoadingDemo.LazyLodingField;

namespace LazyLoadingDemo
{
    public class SlowConstructor
    {
        //public SlowConstructor()
        //{
        //    Console.WriteLine("正在初始化SlowConstructor,请稍等...");
        //    Thread.Sleep(5000);
        //}
        private IMyService _myService;
        public SlowConstructor(IMyService myService)//只有一个构造函数，并且需要一个参数
        {
            _myService = myService;
            Console.WriteLine("正在初始化SlowConstructor,请稍等...");
            Thread.Sleep(5000);
        }
        //public void DoSomething()
        //{
        //    Console.WriteLine("{0}:正在处理一些业务...",DateTime.Now);
        //}

        public void DoSomething()
        {
            _myService.DoSomething();
        }
    }
}
