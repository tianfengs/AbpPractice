using CarRental.Core.Entities;

namespace CarRental.Core.Services.Interface
{
    public interface ILoyaltyRedemptionService
    {
        void Redeem(Invoice invoice, int numberOfDays);
    }
}