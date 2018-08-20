using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransactionCastle
{
    public class InvoiceService
    {
        public virtual void Save(Invoice invoice)
        {
            Console.WriteLine("已保存");
            //该方法总是成功
        }

        private bool isRetry;
        public virtual void SaveRetry(Invoice invoice)
        {
            if (!isRetry)
            {
                Console.WriteLine("第一次保存失败");
                isRetry = true;//该方法第一次总是失败，但之后都是成功
                throw new DataException();
            }
            Console.WriteLine("保存成功");
        }

        public virtual void SaveFail(Invoice invoice)
        {
            Console.WriteLine("保存失败");
            throw new DataException();//该方法总是抛出数据异常
        }
    }
}
