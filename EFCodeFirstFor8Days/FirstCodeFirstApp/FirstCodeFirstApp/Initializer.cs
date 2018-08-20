using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstCodeFirstApp
{
    public class Initializer:DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            //context.PayWays.AddRange(new List<PayWay>
            //{
            //    new PayWay{Name = "支付宝"},
            //    new PayWay{Name = "微信"},
            //    new PayWay{Name = "QQ红包"}
            //});
        }
    }
}
