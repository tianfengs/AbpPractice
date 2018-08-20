using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace DataStructures
{
    public class Program
    {
        public static void Main(string[] args)
        {
            OutputEncoding = Encoding.GetEncoding("utf-8");
            var runCounts = 1000;
            var randomGen = new Random();
            var elementCounts = 100 * 1000;
            var randomDic = new Dictionary<int, double>();
            for (int i = 0; i < elementCounts; i++)
            {
                randomDic.Add(i, randomGen.NextDouble());
            }
            var randomList = randomDic.ToList();
            var randomArray = randomDic.ToArray();
            WriteLine($"对{elementCounts}个元素进行{runCounts}次测量！");
            GC.Collect();
            //foreach测试-Array
            var foreachArrayElemetns = RunTest(() =>
            {
                var sum = 0d;
                foreach (var item in randomArray)
                {
                    sum += item.Value;
                }
                return sum;
            }, runCounts);
            WriteLine($"Array foreach耗时{foreachArrayElemetns}ms!");
            GC.Collect();
            //foreach测试-List
            var foreachListElements = RunTest(() =>
            {
                var sum = 0d;
                foreach (var item in randomList)
                {
                    sum += item.Value;
                }
                return sum;
            }, runCounts);
            WriteLine($"List foreach耗时{foreachListElements}ms!");
            GC.Collect();

            //foreach测试-Dictionary
            var foreachDicElements = RunTest(() =>
            {
                var sum = 0d;
                foreach (var item in randomDic)
                {
                    sum += item.Value;
                }
                return sum;
            }, runCounts);
            WriteLine($"Dictionary foreach耗时{foreachDicElements}ms!");
            GC.Collect();
            WriteLine();
            //for测试-Array
            var forArrayElements = RunTest(() =>
            {
                var sum = 0d;
                for (int i = 0; i < randomArray.Length; i++)
                {
                    sum += randomArray[i].Value;
                }
                return sum;
            }, runCounts);
            WriteLine($"Array for耗时{forArrayElements}ms!");
            GC.Collect();

            //for测试-List
            var forListElements = RunTest(() =>
            {
                var sum = 0d;
                for (int i = 0; i < randomList.Count; i++)
                {
                    sum += randomList[i].Value;
                }
                return sum;
            }, runCounts);
            WriteLine($"List for耗时{forListElements}ms!");
            GC.Collect();

            //for测试-Dictionary
            var forDicElements = RunTest(() =>
            {
                var sum = 0d;
                for (int i = 0; i < randomDic.Count; i++)
                {
                    sum += randomDic[i];
                }
                return sum;
            }, runCounts);
            WriteLine($"Dictionary for耗时{forDicElements}ms!");
            GC.Collect();

            WriteLine();

            var lastKey = randomList.Last().Key;
            //select测试-Array
            var selectArrayElements = RunTest(()=> {
                return randomArray.FirstOrDefault(a => a.Key == lastKey).Value;
            },runCounts);
            WriteLine($"Select Array耗时{selectArrayElements}ms!");
            GC.Collect();
            //select测试-List
            var selectListElements = RunTest(() => {
                return randomList.FirstOrDefault(a => a.Key == lastKey).Value;
            }, runCounts);
            WriteLine($"Select List耗时{selectListElements}ms!");
            GC.Collect();
            //select测试-Dictionary
            var selectDicElements = RunTest(() => {
                double result = 0d;
                if (randomDic.TryGetValue(lastKey,out result))
                {
                    return result;
                }
                return 0d;
            }, runCounts*10000);
            WriteLine($"Select Dictionary{runCounts * 10000}次操作耗时{selectDicElements}ms!真的很快！");
            GC.Collect();

            WriteLine();
            //Array Add测量
            var arrayAdd = RunTest(()=> {
                var arr = new int[elementCounts];
                for (int i = 0; i < elementCounts; i++)
                {
                    arr[i] = i;
                }
                return 0;
            }, runCounts);
            WriteLine($"将{elementCounts}个整型元素加入到Array中需要{arrayAdd}ms!");
            GC.Collect();
            //List Add测量
            var listAdd = RunTest(() => {
                var list = new List<int>();
                for (int i = 0; i < elementCounts; i++)
                {
                    list.Add(i);
                }
                return 0;
            }, runCounts);
            WriteLine($"将{elementCounts}个整型元素加入到List中需要{listAdd}ms!");
            GC.Collect();

            //Dictionary Add测量
            var dicAdd = RunTest(() => {
                var dict = new Dictionary<int, int>();
                for (int i = 0; i < elementCounts; i++)
                {
                    dict.Add(i, i);
                }
                return 0;
            }, runCounts);
            WriteLine($"将{elementCounts}个整型元素加入到Dictionary中需要{dicAdd}ms!");
            GC.Collect();

            WriteLine("测量完成！");
            ResetColor();
            ReadKey(true);
        }

        private static long RunTest(Func<double> func, int runCounts = 1000)
        {
            var stopWatch = Stopwatch.StartNew();
            for (int i = 0; i < runCounts; i++)
            {
                func();
            }
            stopWatch.Stop();
            return stopWatch.ElapsedMilliseconds;
        }
    }
}
