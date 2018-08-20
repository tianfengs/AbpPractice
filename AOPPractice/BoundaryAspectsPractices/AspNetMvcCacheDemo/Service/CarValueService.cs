using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using AspNetMvcCacheDemo.Aspects;
using AspNetMvcCacheDemo.Models;

namespace AspNetMvcCacheDemo.Service
{
    public class CarValueService
    {
        readonly Random _ran;

        public CarValueService()
        {
            _ran=new Random();
        }

        [CacheAspect]
        public decimal GetValue(int year,string makeId,string conditionId)
        {
            Thread.Sleep(5000);
            return _ran.Next(1000000, 10000000);
        }

        [CacheAspect]
        public decimal GetValueBetter(CarValueArgs args)
        {
            Thread.Sleep(5000);
            return _ran.Next(1000000, 10000000);
        }
    }
}