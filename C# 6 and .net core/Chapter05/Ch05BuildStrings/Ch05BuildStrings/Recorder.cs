using static System.Console;
using System.Diagnostics;
using static System.Diagnostics.Process;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Ch05BuildStrings
{
    class Recorder
    {
        static Stopwatch timer = new Stopwatch();
        static long bytesPhysicalBefore = 0;
        static long bytesVirtualBefore = 0;
        public static void Start()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            bytesPhysicalBefore = GetCurrentProcess().WorkingSet64;
            bytesVirtualBefore = GetCurrentProcess().VirtualMemorySize64;
            timer.Restart();
        }
        public static void Stop()
        {
            timer.Stop();
            long bytesPhysicalAfter = GetCurrentProcess().WorkingSet64;
            long bytesVirtualAfter = GetCurrentProcess().VirtualMemorySize64;
            WriteLine("Stopped recording.");
            WriteLine($"{bytesPhysicalAfter - bytesPhysicalBefore:N0} physical bytes used.");
            WriteLine($"{bytesVirtualAfter - bytesVirtualBefore:N0} virtual bytes used.");
            WriteLine($"{timer.Elapsed} time span ellapsed.");
            WriteLine($"{timer.ElapsedMilliseconds:N0} total milliseconds ellapsed.");
        }
    }
}
