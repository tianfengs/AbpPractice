using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiBoWithPostSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var weiboService=new WeiBoClient();
            weiboService.Send("hi");
            Console.WriteLine();
            Console.Read();
        }
    }
}
