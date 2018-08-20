using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Castle.DynamicProxy;

namespace DataTransactionCastle
{
    public class TransactionWithRetries:IInterceptor
    {
        private readonly int _maxRetries;
        public TransactionWithRetries(int maxRetries)
        {
            _maxRetries = maxRetries;
        }
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("拦截器开始：" + DateTime.Now);
            //using (var ts = new TransactionScope())//创建一个事务范围对象
            //{
            //    invocation.Proceed();//执行被拦截的方法
            //    ts.Complete();//事务完成
            //}
            var isSucceeded = false;
            var retries = _maxRetries;
            while (!isSucceeded)
            {
                using (var ts = new TransactionScope())
                {
                    try
                    {
                        invocation.Proceed();
                        ts.Complete();
                        isSucceeded = true;
                    }
                    catch (Exception)
                    {
                        if (retries>=0)
                        {
                            Console.WriteLine("重试方法{0}中...",invocation.Method.Name);
                            retries--;
                        }
                        else
                        {
                            throw;
                        }
                    }

                }
            }
            Console.WriteLine("拦截器结束："+DateTime.Now);
        }
    }
}
