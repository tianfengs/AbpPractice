using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Core.Services.Interface;

namespace CarRental.Core.Services.Impl
{
    public class FakeLoyalDataService:ILoyaltyDataService
    {
        public void AddPoints(Guid customerId, int points)
        {
            Console.WriteLine("客户{0}增加了{1}积分",customerId,points);
        }

        public void SubstractPoints(Guid customerId, int points)
        {
            Console.WriteLine("客户{0}减少了{1}积分", customerId, points);
        }
    }
}
