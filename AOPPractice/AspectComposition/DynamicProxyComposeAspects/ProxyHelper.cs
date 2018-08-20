using DynamicProxyComposeAspects;
using StructureMap.Building.Interception;
using StructureMap.Pipeline;
using System;
using System.Collections.Generic;

public class DynamicProxyHelper
{
    public static object CreateInterfaceProxyWithTargetInterface(Type interfaceType, object concreteObject)
    {
        var dynamicProxy = new Castle.DynamicProxy.ProxyGenerator();

        var result = dynamicProxy.CreateInterfaceProxyWithTargetInterface(
            interfaceType,
            concreteObject,
            new Castle.DynamicProxy.IInterceptor[] { new Aspect1(),new Aspect2()});

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
        if (pluginType == typeof(IMyClass))
        {
            // DecoratorInterceptor is the simple case of wrapping one type with another
            // concrete type that takes the first as a dependency
            yield return new FuncInterceptor<IMyClass>(i =>
                        (IMyClass)
                            DynamicProxyHelper.CreateInterfaceProxyWithTargetInterface(typeof(IMyClass), i));
        }
    }
}