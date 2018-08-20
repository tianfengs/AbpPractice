using StackExchange.Redis;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _8_Profiling
{
    public class ToyProfiler : IProfiler
    {
        public ConcurrentDictionary<Thread, object> Contexts = new ConcurrentDictionary<Thread, object>();
        public object GetContext()
        {
            object context;
            if (!Contexts.TryGetValue(Thread.CurrentThread, out context))
                context = null;
            return context;
        }
    }
}
