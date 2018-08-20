using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;
using System.Security.Cryptography;
namespace ParallelBenchMarking
{
    public class Program
    {
        private const int runs = 1000;
        private const int length = 100000;

        private const int hashRuns = 10;
        private const int iterations = 10000;
        public static void Main(string[] args)
        {
            ForegroundColor = ConsoleColor.White;
            WriteLine($"Testing summing {length} integers over {runs} runs! ");

            //prepare test data
            var intArr = new int[length];
            var rng = new Random();
            for (int i = 0; i < length; i++)
            {
                intArr[i] = rng.Next(10);
            }
            var intList = intArr.ToList();
            GC.Collect();

            //test for loop
            ForegroundColor = ConsoleColor.White;
            WriteLine("Simple for loops!");
            WriteLine("-Array:");
            RunTest(() =>
            {
                var sum = 0;
                for (int i = 0; i < intArr.Length; i++)
                {
                    sum += intArr[i];
                }
                return sum;
            });

            WriteLine("-List:");
            RunTest(() =>
            {
                var sum = 0;
                for (int i = 0; i < intList.Count; i++)
                {
                    sum += intList[i];
                }
                return sum;
            });

            //test foreach loop
            ForegroundColor = ConsoleColor.White;
            WriteLine("test simple foreach");
            WriteLine("-Array:");
            RunTest(() =>
            {
                var sum = 0;
                foreach (var i in intArr)
                {
                    sum += i;
                }
                return sum;
            });
            WriteLine("-List:");
            RunTest(() =>
            {
                var sum = 0;
                foreach (var i in intList)
                {
                    sum += i;
                }
                return sum;
            });

            ForegroundColor = ConsoleColor.Gray;
            WriteLine($"Bad Parallel foreach(no interlocked add)");
            WriteLine("-Array:");
            RunTest(() =>
            {
                var sum = 0;
                Parallel.ForEach(intArr, i =>
                {
                    sum += i;//do not do this!!!
                });
                return sum;
            });

            ForegroundColor = ConsoleColor.White;
            WriteLine("Parallel Foreach!");
            WriteLine("-Array:");
            RunTest(() =>
            {
                var sum = 0;
                Parallel.ForEach(intArr, i =>
                {
                    Interlocked.Add(ref sum, i);
                });
                return sum;
            });

            WriteLine("-List:");
            RunTest(() =>
            {
                var sum = 0;
                Parallel.ForEach(intList, i =>
                {
                    Interlocked.Add(ref sum, i);
                });
                return sum;
            });
            WriteLine();
            ForegroundColor = ConsoleColor.Gray;
            WriteLine("Parallel for:");
            WriteLine("-Array:");
            RunTest(() =>
            {
                var sum = 0;
                Parallel.For(0, intArr.Length, i =>
                {
                    Interlocked.Add(ref sum, intArr[i]);
                });
                return sum;
            });
            WriteLine("-List:");
            RunTest(() =>
            {
                var sum = 0;
                Parallel.For(0, intList.Count, i =>
                 {
                     Interlocked.Add(ref sum, intList[i]);
                 });
                return sum;
            });

            WriteLine();
            WriteLine();

            ForegroundColor = ConsoleColor.White;
            var passwords = new List<string> { "password", "cohobast", "changeme", "qwert123" };
            WriteLine($"PBKDF2 over {hashRuns} runs hashing {passwords.Count} passwords ({iterations} iterations)...");
            WriteLine();
            ForegroundColor = ConsoleColor.Gray;
            WriteLine("Simple foreach loop:");
            RunHashTest(() =>
            {
                foreach (var pwd in passwords)
                {
                    var pbkdf2 = new Rfc2898DeriveBytes(pwd, 256, iterations);
                    Convert.ToBase64String(pbkdf2.GetBytes(256));
                }
            });
            WriteLine();
            ForegroundColor = ConsoleColor.White;
            WriteLine("Parallel.ForEach() ");
            RunHashTest(() =>
            {
                Parallel.ForEach(passwords, pwd =>
                {
                    var pbkdf2 = new Rfc2898DeriveBytes(pwd, 256, iterations);
                    Convert.ToBase64String(pbkdf2.GetBytes(256));
                });
            });
            WriteLine();
            ForegroundColor = ConsoleColor.Gray;
            WriteLine("AsParallel().ForAll() ");
            RunHashTest(() =>
            {
                passwords.AsParallel().ForAll(pwd =>
                {
                    var pbkdf2 = new Rfc2898DeriveBytes(pwd, 256, iterations);
                    Convert.ToBase64String(pbkdf2.GetBytes(256));
                });
            });

            WriteLine();
            ForegroundColor = ConsoleColor.White;
            WriteLine(" AsParallel().WithDegreeOfParallelism(2).ForAll");
            RunHashTest(()=> {
                passwords.AsParallel().WithDegreeOfParallelism(2).ForAll(pwd =>
                {
                    var pbkdf2 = new Rfc2898DeriveBytes(pwd, 256, iterations);
                    Convert.ToBase64String(pbkdf2.GetBytes(256));
                });
            });
            ReadKey(true);
        }

        private static void RunTest(Func<int> func)
        {
            int result = 0;
            var s = Stopwatch.StartNew();
            for (int i = 0; i < runs; i++)
            {
                result = func();
            }
            s.Stop();
            WriteLine($"Total Time:{s.ElapsedMilliseconds:0000} ms,last reuslt={result}");
            GC.Collect();
        }

        private static void RunHashTest(Action func)
        {
            var s = Stopwatch.StartNew();
            for (int i = 0; i < hashRuns; i++)
            {
                func();
            }
            s.Stop();
            WriteLine($"Total Time:{s.ElapsedMilliseconds:0000} ms");
            GC.Collect();
        }
    }
}
