using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LazyLoadingDemo.LazyLodingField;
using StructureMap;

namespace LazyLoadingDemo
{
    class Program
    {

        #region 1.0 懒加载属性

        //[MyLazyLoadingGetterAspect]
        //static SlowConstructor SlowService
        //{
        //    get { return new SlowConstructor(); }
        //} 
        #endregion

        #region 2.0 懒加载字段
        //[MyLazyLoadingFieldAspect]
        [LazyLoadStructureMapAspect]
        private static SlowConstructor SlowService;
        #endregion
        static void Main(string[] args)
        {
            //ObjectFactory.Initialize告诉StructureMap使用哪个实现
            ObjectFactory.Initialize(cfg =>
            {
                cfg.For<IMyService>().Use<MyService>();//当调用IMyService的构造函数时，使用MyService作为实现
                cfg.For<SlowConstructor>().Use<SlowConstructor>();//这行代码可选，StructureMap会自动绑定
            });
            SlowService.DoSomething();
            SlowService.DoSomething();

            Console.Read();
        }
    }
}
