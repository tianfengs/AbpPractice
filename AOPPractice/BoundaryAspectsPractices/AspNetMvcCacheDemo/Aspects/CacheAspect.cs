using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using PostSharp.Aspects;

namespace AspNetMvcCacheDemo.Aspects
{
    [Serializable]
    public class CacheAspect : OnMethodBoundaryAspect
    {
        /// <summary>
        /// 进入方法前执行的边界方法，进入服务类方法前先检测一下缓存中是否有数据，有就直接返回缓存中的数据
        /// </summary>
        /// <param name="args"></param>
        public override void OnEntry(MethodExecutionArgs args)
        {
            var key = GetCacheKeyBetter(args);
            if (HttpContext.Current.Cache[key] == null)
            {
                return;//退出OnEntry方法，继续执行服务类方法
            }
            args.ReturnValue = HttpContext.Current.Cache[key];
            args.FlowBehavior = FlowBehavior.Return;//这里的Return指的是跳过服务类方法
        }
        /// <summary>
        /// 方法成功执行后执行的边界方法，调用第三方服务成功后缓存获取的结果
        /// </summary>
        /// <param name="args"></param>
        public override void OnSuccess(MethodExecutionArgs args)
        {
            //var key = GetCacheKey(args);
            var key = GetCacheKeyBetter(args);
            HttpContext.Current.Cache[key] = args.ReturnValue;
        }
        /// <summary>
        /// 获取Cache键，对应服务类方法有多个参数的版本
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private string GetCacheKey(MethodExecutionArgs args)
        {
            var contactArgs = string.Join("_", args.Arguments);
            contactArgs = args.Method.Name + "-" + contactArgs;
            return contactArgs;
        }
        /// <summary>
        /// 获取Cache键，升级版本，对应服务类方法只有一个对象参数
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private string GetCacheKeyBetter(MethodExecutionArgs args)
        {
            //方法1：通过JsonConvert
            //var jsonArr = args.Arguments.Select(JsonConvert.SerializeObject).ToArray();
            var jsonArr = args.Arguments.Select(new JavaScriptSerializer().Serialize).ToArray();
            return args.Method.Name+"_" + string.Join("_", jsonArr);
        }
    }

}