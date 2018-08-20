using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Diagnostics;
using System.Threading;

namespace Ch12_LockAndMonitor
{
    class Program
    {
        static Random ran = new Random();
        static string Msg;//共享资源
        static int Counter;//共享资源二，计数字符串的修改次数
        static object conch = new object();//命名来源一个故事，持有贝壳的人才能资格讲话
        static void Main(string[] args)
        {
            WriteLine("请等待多个任务运行完成");
            var timer = new Stopwatch();
            timer.Start();
            Task tA = Task.Factory.StartNew(MethodA);
            Task tB = Task.Factory.StartNew(MethodB);
            //Task tA = Task.Factory.StartNew(MethodALock);
            //Task tA = Task.Factory.StartNew(MethodAMonitor);
            //Task tB = Task.Factory.StartNew(MethodBLock);

            Task.WaitAll(new Task[] { tA, tB });
            WriteLine(Msg);
            WriteLine($"耗时：{timer.ElapsedMilliseconds:#,##0} ms");
            WriteLine($"{nameof(Msg)}被修改了{Counter}次");
            Read();
        }
        /// <summary>
        /// 不加锁
        /// </summary>
        static void MethodA()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(ran.Next(2000));
                Msg += "A";
                Interlocked.Increment(ref Counter);//原子操作
                //Counter++;//CPU操作一个自增需要3步，因此可能造成数据损失
                Write(i+1);
            }
        }
        static void MethodB()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(ran.Next(2000));
                Msg += "B";
                Interlocked.Increment(ref Counter);
               // Counter++;
                Write(i + 1);
            }
        }


        /// <summary>
        /// 加锁,lock语句可能会造成死锁
        /// </summary>
        static void MethodALock()
        {
            lock (conch)
            {
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(ran.Next(2000));
                    Msg += "A";
                    Write(i + 1);
                }
            }
           
        }
        static void MethodBLock()
        {
            lock (conch)
            {
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(ran.Next(2000));
                    Msg += "B";
                    Write(i + 1);
                }
            }
           
        }

        static void MethodAMonitor()
        {
            try
            {
                Monitor.TryEnter(conch, TimeSpan.FromSeconds(15));
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(ran.Next(2000));
                    Msg += "A";
                    Write(i + 1);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Monitor.Exit(conch);
            }
        }

    }
}
