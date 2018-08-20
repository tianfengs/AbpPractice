using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Core.Entities;
using CarRental.Core.Services.Interface;

namespace CarRental.Core.AOPRefactor.Services
{
    public class LoyaltyAccrualService:ILoyaltyAccrualService
    {
        private readonly ILoyaltyDataService _loyaltyDataService;
        public LoyaltyAccrualService(ILoyaltyDataService loyaltyDataService)
        {
            _loyaltyDataService = loyaltyDataService;
        }
        [LoggingAspect]
        [DefensiveProgramming]
        [TransactionManagement]
        [MyExceptionAspect]
        public void Accrue(RentalAgreement agreement)
        {
            var rentalTime = agreement.EndDate.Subtract(agreement.StartDate);
            var days = (int) Math.Floor(rentalTime.TotalDays);
            var pointsPerDay = 1;
            if (agreement.Vehicle.Size>=Size.Luxury)
            {
                pointsPerDay = 2;
            }
            var totalPoints = days*pointsPerDay;
            _loyaltyDataService.AddPoints(agreement.Customer.Id,totalPoints);
        }
    }
}
