using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;
using static System.Console;
using System.Threading;
using System.Collections.Concurrent;

namespace _8_Profiling
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionMultiplexer conn = ConnectionMultiplexer.Connect("localhost,allowAdmin=true");
            var server = conn.GetServer("localhost:6379");
            //擦除该服务器上的所有数据库的数据
            server.FlushAllDatabases();
            var profiler = new ToyProfiler();
            conn.RegisterProfiler(profiler);
            var threads = new List<Thread>();
            #region V1
            //var thisGroupContext = new object();
            //for (var i = 0; i < 16; i++)
            //{
            //    var db = conn.GetDatabase(i);

            //    var thread =
            //        new Thread(
            //            delegate ()
            //            {
            //                var threadTasks = new List<Task>();

            //                for (var j = 0; j < 1000; j++)
            //                {
            //                    var task = db.StringSetAsync("" + j, "" + j);
            //                    threadTasks.Add(task);
            //                }

            //                Task.WaitAll(threadTasks.ToArray());
            //            }
            //        );

            //    profiler.Contexts[thread] = thisGroupContext;

            //    threads.Add(thread);
            //}

            //conn.BeginProfiling(thisGroupContext);

            //threads.ForEach(thread => thread.Start());
            //threads.ForEach(thread => thread.Join());

            //IEnumerable<IProfiledCommand> timings = conn.FinishProfiling(thisGroupContext);
            #endregion

            var perThreadTimings = new ConcurrentDictionary<Thread, List<IProfiledCommand>>();

            for (var i = 0; i < 16; i++)
            {
                var db = conn.GetDatabase(i);

                var thread =
                    new Thread(
                        delegate ()
                        {
                            var threadTasks = new List<Task>();

                            conn.BeginProfiling(Thread.CurrentThread);

                            for (var j = 0; j < 1000; j++)
                            {
                                var task = db.StringSetAsync("" + j, "" + j);
                                threadTasks.Add(task);
                            }

                            Task.WaitAll(threadTasks.ToArray());

                            perThreadTimings[Thread.CurrentThread] = conn.FinishProfiling(Thread.CurrentThread).ToList();
                        }
                    );

                profiler.Contexts[thread] = thread;

                threads.Add(thread);
            }

            threads.ForEach(thread => thread.Start());
            threads.ForEach(thread => thread.Join());
            ReadLine();
        }
    }
}
