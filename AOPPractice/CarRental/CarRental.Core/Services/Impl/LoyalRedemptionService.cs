using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using CarRental.Core.Entities;
using CarRental.Core.Services.Interface;

namespace CarRental.Core.Services.Impl
{
    public class LoyalRedemptionService:ILoyaltyRedemptionService
    {
        private readonly ILoyaltyDataService _loyaltyDataService;

        public LoyalRedemptionService(ILoyaltyDataService loyaltyDataService)
        {
            _loyaltyDataService = loyaltyDataService;
        }

        public void Redeem(Invoice invoice, int numberOfDays)
        {
            //防御性编程
            if (invoice==null)
            {
                throw new Exception("invoice为null！");
            }
            if (numberOfDays<=0)
            {
                throw new Exception("numberOfDays不能小于1！");
            }
            //logging
            Console.WriteLine("Redeem:{0}",DateTime.Now);
            Console.WriteLine("Invoice:{0}",invoice.Id);
            using (var ts=new TransactionScope())
            {
                try
                {
                    var pointsPerDay = 10;
                    if (invoice.Vehicle.Size >= Size.Luxury)
                    {
                        pointsPerDay = 15;
                    }
                    var totalPoints = pointsPerDay * numberOfDays;
                    invoice.Discount = numberOfDays * invoice.CostPerDay;
                    _loyaltyDataService.SubstractPoints(invoice.Customer.Id, totalPoints);
                    ts.Complete();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            Console.WriteLine("Redeem Complete:{0}",DateTime.Now);
        }
    }
}
