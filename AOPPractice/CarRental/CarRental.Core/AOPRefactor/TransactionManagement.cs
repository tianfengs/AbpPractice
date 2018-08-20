using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using PostSharp.Aspects;

namespace CarRental.Core.AOPRefactor
{
    [Serializable]
    public class TransactionManagement : MethodInterceptionAspect
    {
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            Console.WriteLine("{0}方法开始：{1}", args.Method.Name, DateTime.Now);
            using (var ts = new TransactionScope())
            {
                var retries = 3;//重试3次
                var succeeded = false;
                while (!succeeded)
                {
                    try
                    {
                        args.Proceed();//继续执行拦截的方法
                        ts.Complete();//事务完成
                        succeeded = true;
                    }

                    catch (Exception ex)
                    {
                        if (retries >= 0)
                            retries--;
                        else
                            throw ex;
                    }
                }
            }
            Console.WriteLine("{0}方法结束：{1}", args.Method.Name,DateTime.Now);
        }
    }
}
