using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Aspects;

namespace PostSharpLocationInterceptionDemo
{
    [Serializable]
    public class MyLocationAspect:LocationInterceptionAspect
    {
        public override void OnGetValue(LocationInterceptionArgs args)
        {
            Console.WriteLine("这条语句来自位置拦截的{0}方法",MethodBase.GetCurrentMethod());
            args.ProceedGetValue();
        }

        public override void OnSetValue(LocationInterceptionArgs args)
        {
            Console.WriteLine("这条语句来自位置拦截的{0}方法", MethodBase.GetCurrentMethod());
            args.ProceedSetValue();
        }
    }
}
