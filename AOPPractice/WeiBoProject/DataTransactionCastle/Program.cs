using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace DataTransactionCastle
{
    class Program
    {
        static void Main(string[] args)
        {
            //var srv=new InvoiceService();

            var proxyGenerator = new ProxyGenerator();
            //使用被拦截的类和自定义的切面类创建动态代理
            var srv = proxyGenerator.CreateClassProxy<InvoiceService>(new TransactionWithRetries(3));
            var invoice=new Invoice
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Items = new List<string>() { "1","2","3"}
            };
            //srv.Save(invoice);//使用这个Save方法来测试一下
            srv.SaveRetry(invoice);
           // srv.SaveFail(invoice);
            Console.WriteLine("执行结束");
            Console.Read();
        }
    }
}
