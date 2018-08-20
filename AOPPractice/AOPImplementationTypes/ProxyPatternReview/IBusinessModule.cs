using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace ProxyPatternReview
{
    public interface IBusinessModule
    {
        void Method1();
    }

    public class BusinessModule : IBusinessModule
    {
        public void Method1()
        {
            WriteLine(nameof(Method1));//输出方法名称
        }
    }

    public class BusinessModuleProxy : IBusinessModule
    {
        BusinessModule _bm;
        public BusinessModuleProxy()
        {
            _bm = new BusinessModule();
        }
        public void Method1()
        {
            WriteLine($"{nameof(Method1)} begin!");
            _bm.Method1();
            WriteLine($"{nameof(Method1)} end!");
        }
    }
}
