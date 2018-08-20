using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PostSharp.Aspects;

namespace WeiboWindow
{
    [Serializable]
    public class WorkerThread:MethodInterceptionAspect
    {
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            //var thread=new Thread(args.Proceed);//将被拦截的方法传入线程构造函数
            //thread.Start();

            var task=new Task(args.Proceed);
            task.Start();
        }
    }
}
