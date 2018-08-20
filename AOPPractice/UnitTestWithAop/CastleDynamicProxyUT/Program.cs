using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using StructureMap;
using StructureMap.Graph;

namespace CastleDynamicProxyUT
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 1.0 不使用StructureMap的情况
            //var service2=new ServiceTwo();
            //var service1=new ServiceOne(service2);
            //service1.DoWorkOne();
            #endregion

            #region 2.0 使用StructureMap
            //ObjectFactory.Initialize(config =>//不同的IOC工具初始化代码是不同的
            //{
            //    config.Scan(scanner =>
            //    {
            //        scanner.TheCallingAssembly();
            //        scanner.WithDefaultConventions();//使用默认的惯例
            //    });
            //    var proxyGenerator = new ProxyGenerator();
            //    var aspect = new LoggingAspect(new LoggingService());
            //    var service = new ServiceOne(new ServiceTwo());
            //    var result = proxyGenerator.CreateInterfaceProxyWithTargetInterface(typeof(IServiceOne), service, aspect);//应用切面
            //    config.For<IServiceOne>().Use((IServiceOne) result);//告诉StructureMap使用产生的动态代理
            //});


            //var service1 = ObjectFactory.GetInstance<IServiceOne>();
            //service1.DoWorkOne();
            #endregion

            #region 3.0 使用EnrichWith重构
            ObjectFactory.Initialize(config =>
            {
                config.Scan(scanner =>
                {
                    scanner.TheCallingAssembly();
                    scanner.WithDefaultConventions();
                });
                var proxyGenerator = new ProxyGenerator();
                //EnrichWith期待传入一个Func参数
                config.For<IServiceOne>().Use<ServiceOne>().EnrichWith(svc =>
                {
                    var aspect = new LoggingAspect(new LoggingService());
                    var result = proxyGenerator.CreateInterfaceProxyWithTargetInterface(typeof(IServiceOne), svc, aspect);
                    return result;
                });
            });

            #endregion

            #region 4.0使用ProxyHelper重构
            ObjectFactory.Initialize(config =>
            {
                config.Scan(scanner =>
                {
                    scanner.TheCallingAssembly();
                    scanner.WithDefaultConventions();
                });
                var proxyHelper = new ProxyHelper();
                //注意Proxify方法本身以实参传入EnrichWith方法
                config.For<IServiceOne>().Use<ServiceOne>().EnrichWith(proxyHelper.Proxify<IServiceOne, LoggingAspect>);
            });
            #endregion
            Console.Read();
        }
    }
}
