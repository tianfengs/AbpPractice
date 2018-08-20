using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch05BuildStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Enumerable.Range(1, 10000).ToArray();
            WriteLine("使用Sting");
            Recorder.Start();
            string str = string.Empty;
            foreach (var n in numbers)
            {
                str +=n+ ",";
            }
            Recorder.Stop();
            WriteLine("使用StringBuilder");
            Recorder.Start();
            var sb = new StringBuilder();
            foreach (var m in numbers)
            {
                sb.Append(m+",");
                //sb.Append(",");//这种写法更占内存
            }
            Recorder.Stop();
            Read();
        }
    }
}
