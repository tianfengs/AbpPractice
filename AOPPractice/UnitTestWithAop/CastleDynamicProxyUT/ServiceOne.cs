﻿using System;

namespace CastleDynamicProxyUT
{
    public class ServiceOne:IServiceOne
    {
        public ServiceOne(IServiceTwo serviceTwo)
        {
            //虽然没有使用IServiceTwo依赖，但是没有它，ServiceOne是不能实例化的
        }
        public void DoWorkOne()
        {
            Console.WriteLine("ServiceOne's DoWorkOne finished the execution!");
        }
    }
}