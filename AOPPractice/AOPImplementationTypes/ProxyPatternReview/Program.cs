using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace ProxyPatternReview
{
    class Program
    {
        static void Main(string[] args)
        {
            //IBusinessModule bm = new BusinessModule();
            //bm.Method1();

            IBusinessModule bmProxy = new BusinessModuleProxy();
            bmProxy.Method1();
            ReadKey();
        }
    }
}
