using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;
using System.Text;
using System.Security.Cryptography;
namespace Hashing
{
    public class Program
    {
        private const int runs = 100 * 1000;
        private const string hashingData = "My hashing test data";

        public static void Main(string[] args)
        {
            var key = new byte[256];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(key);
            var algos = new SortedList<string, HashAlgorithm>
            {
                {"1.MD5",MD5.Create() },//MD5不安全了
                {"2.SHA-1",SHA1.Create()},//SHA-1也过时了
                {"3.SHA-256",SHA256.Create() },
                {"4.HMAC SHA-1",new HMACSHA1(key) },
                {"5.HMAC SHA-256",new HMACSHA256(key) }
            };
            foreach (var algo in algos)
            {
                ForegroundColor++;
                HashAlgorithmTest(algo);
            }
            ForegroundColor++;

            //PBKDF2 is so slow that 100,000 runs will take long time.
            var slowRuns = 10;
            var pbkdf2 = new Rfc2898DeriveBytes(hashingData, key, 10000);
            var pbkdf2Ms = RunTest(() =>
            {
                pbkdf2.GetBytes(256);
            }, slowRuns);
            WriteLine($"6. PBKDF2 average time: {pbkdf2Ms}ms over {slowRuns} runs");
            ResetColor();
            WriteLine("Press any key to exit...");
            ReadKey(true);
        }

        private static void HashAlgorithmTest(KeyValuePair<string, HashAlgorithm> algo)
        {
            byte[] smallBytes = Encoding.UTF8.GetBytes(hashingData);
            var largeBytes = new byte[smallBytes.Length * 100];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(largeBytes);
            var smallTimeMs = RunTest(() =>
            {
                algo.Value.ComputeHash(smallBytes);
            }, runs);
            var largeTimeMs = RunTest(() =>
            {
                algo.Value.ComputeHash(largeBytes);
            });
            var avgSmallTimeMs = (double)smallTimeMs / runs;
            var avgLargeTimeMs = (double)largeTimeMs / runs;
            WriteLine($"{algo.Key} average time: {smallBytes.Length}B-{avgSmallTimeMs:0.00000}ms, {largeBytes.Length}B-{avgLargeTimeMs:0.00000}ms");
        }
        private static long RunTest(Action func, int runs = 1000)
        {
            var s = Stopwatch.StartNew();
            for (int i = 0; i < runs; i++)
            {
                func();
            }
            s.Stop();
            return s.ElapsedMilliseconds;
        }
    }
}
