using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballStatsPostSharp
{
    public class BasketballStatsService
    {
        /// <summary>
        /// 根据球员的名字返回球员的球衣号码
        /// </summary>
        /// <param name="playerName"></param>
        /// <returns></returns>
        [MyBoundaryAspect]
        public string GetPlayerNumber(string playerName)
        {
            if (playerName.Equals("Michael Jordan"))
            {
                return 23.ToString();
            }
            if (playerName.Equals("Kobe Bryant"))
            {
                return 24.ToString();
            }
            return 0.ToString();
        }

        [MyBoundaryAspect]
        public void Test()
        {
            
        }
    }
}
