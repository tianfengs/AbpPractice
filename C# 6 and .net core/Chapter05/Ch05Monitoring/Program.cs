using static System.Console;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch05Monitoring
{
    class Program
    {

        static void Main(string[] args)
        {
            Write("Press ENTER to start the timer: ");
            ReadLine();
            Recorder.Start();
            int[] largeArrayOfInts = Enumerable.Range(1, 10000).ToArray();
            Write("Press ENTER to stop the timer: ");
            ReadLine();
            Recorder.Stop();
            ReadLine();
        }
    }
}
