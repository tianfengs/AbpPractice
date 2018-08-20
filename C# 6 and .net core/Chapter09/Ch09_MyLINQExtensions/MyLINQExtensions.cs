using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch09_MyLINQExtensions
{
    public static class MyLINQExtensions
    {
        /// <summary>
        /// 链式的扩展方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public static IEnumerable<T> ProcessSequence<T>(this IEnumerable<T> sequence)
        {
            return sequence;
        }

        /// <summary>
        /// 汇总式的扩展方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public static long GetSequenceCount<T>(this IEnumerable<T> sequence)
        {
            return sequence.LongCount();
        }
    }
}
