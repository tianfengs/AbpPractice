using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Core.Entities;
using CarRental.Core.Services.Interface;

namespace CarRental.Core.AOPRefactor.Services
{
    public class LoyalRedemptionService:ILoyaltyRedemptionService
    {
         private readonly ILoyaltyDataService _loyaltyDataService;
         public LoyalRedemptionService(ILoyaltyDataService loyaltyDataService)
        {
            _loyaltyDataService = loyaltyDataService;
        }
        [LoggingAspect]
        [DefensiveProgramming]
        [TransactionManagement]
        [MyExceptionAspect]
        public void Redeem(Invoice invoice, int numberOfDays)
        {
            var pointsPerday = 10;
            if (invoice.Vehicle.Size>=Size.Luxury)
            {
                pointsPerday = 15;
            }
            var totalPoints = numberOfDays*pointsPerday;
            _loyaltyDataService.SubstractPoints(invoice.Customer.Id,totalPoints);
            invoice.Discount = numberOfDays*invoice.CostPerDay;
        }
    }
}
