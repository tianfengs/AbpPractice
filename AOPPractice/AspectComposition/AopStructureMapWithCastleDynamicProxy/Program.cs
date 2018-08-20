using System;
using System.Collections.Generic;
using StructureMap;
using StructureMap.Building.Interception;
using StructureMap.Pipeline;

namespace AOPStructureMap
{
    public interface IAppService
    {
        void DoWork();
    }

    public class AppService1 : IAppService
    {
        public void DoWork()
        {
            Console.WriteLine("Hi from " + GetType().Name);
        }
    }
    public class AppService2 : IAppService
    {
        public void DoWork()
        {
            Console.WriteLine("Hi from " + GetType().Name);
        }
    }
    public class AppService3 : IAppService
    {
        public void DoWork()
        {
            Console.WriteLine("Hi from " + GetType().Name);
        }
    }
    public class MyExInterceptor : Castle.DynamicProxy.IInterceptor
    {
        public void Intercept(Castle.DynamicProxy.IInvocation invocation)
        {
            Console.WriteLine("-- Call to " + invocation.Method);
            invocation.Proceed();
        }
    }

    public class DynamicProxyHelper
    {
        public static object CreateInterfaceProxyWithTargetInterface(Type interfaceType, object concreteObject)
        {
            var dynamicProxy = new Castle.DynamicProxy.ProxyGenerator();

            var result = dynamicProxy.CreateInterfaceProxyWithTargetInterface(
                interfaceType,
                concreteObject,
                new[] { new MyExInterceptor() });

            return result;
        }
    }

    public class CustomInterception : IInterceptorPolicy
    {
        public string Description
        {
            get { return "good interception policy"; }
        }

        public IEnumerable<IInterceptor> DetermineInterceptors(Type pluginType, Instance instance)
        {
            if (pluginType == typeof(IAppService))
            {
                // DecoratorInterceptor is the simple case of wrapping one type with another
                // concrete type that takes the first as a dependency
                yield return new FuncInterceptor<IAppService>(i =>
                            (IAppService)
                                DynamicProxyHelper.CreateInterfaceProxyWithTargetInterface(typeof(IAppService), i));
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container(_ =>
            {
                _.For<IAppService>()
                    .DecorateAllWith(
                        instance =>
                            (IAppService)
                                DynamicProxyHelper.CreateInterfaceProxyWithTargetInterface(typeof(IAppService), instance));
                _.For<IAppService>().Use<AppService1>();
            });

            var service = container.GetInstance<IAppService>();
            service.DoWork();

            container = new Container(_ =>
            {
                _.For<IAppService>()
                    .DecorateAllWith(
                        instance =>
                            (IAppService)
                                DynamicProxyHelper.CreateInterfaceProxyWithTargetInterface(typeof(IAppService), instance));
                _.For<IAppService>().Use<AppService2>();
            });

            service = container.GetInstance<IAppService>();
            service.DoWork();

            container = new Container(_ =>
            {
                _.Policies.Interceptors(new CustomInterception());

                _.For<IAppService>().Use<AppService3>();
            });

            service = container.GetInstance<IAppService>();
            service.DoWork();

            Console.ReadKey();
        }
    }
}