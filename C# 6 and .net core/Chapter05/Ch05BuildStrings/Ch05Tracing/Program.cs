using System.Diagnostics;
using static System.Console;
namespace Ch05_Tracing
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.WriteLine("Debug says Hello C#!");
            Trace.WriteLine("Trace says Hello C#!");
#if FARBDebug
            Debug.WriteLine("FarbDebug开启");
#endif

            var ts = new TraceSwitch("farbSwitch", "");
            Trace.WriteLineIf(ts.TraceError, "TraceError");
            Trace.WriteLineIf(ts.TraceWarning, "TraceWarning");
            Trace.WriteLineIf(ts.TraceInfo, "TraceInfo");
            Trace.WriteLineIf(ts.TraceVerbose, "TraceVerbose");
            Trace.Close(); // release any file or database listeners
            WriteLine("Press ENTER to close.");
            ReadLine();
            WriteLine("Press ENTER to close.");
            ReadLine();
        }
    }
}