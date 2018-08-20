using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballStatsPostSharp
{
    class Program
    {
        static void Main(string[] args)
        {//这个花括号是程序没有执行和开始执行的分界线
            #region PostSharp方法边界
            //var service = new BasketballStatsService();
            //var playName = "Michael Jordan";
            //var no1 = service.GetPlayerNumber(playName);//这里是Main方法和GetPlayerNumber方法的分界线
            //Console.WriteLine("{0}的球衣号码是{1}", playName, no1);
            
            #endregion


            #region 拦截切面VS边界切面
            var s1=new BasketballStatsService();
            var s2=new BasketballStatsService();
            s1.GetPlayerNumber("Kobe Bryant");
            s2.GetPlayerNumber("Kobe Bryant");
            //s1.Test();
            #endregion
            Console.Read();
        }//这个花括号是程序结束前和程序结束后的分界线
    }
}
