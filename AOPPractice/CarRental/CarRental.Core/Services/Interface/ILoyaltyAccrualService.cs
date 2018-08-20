using CarRental.Core.Entities;

namespace CarRental.Core.Services.Interface
{
    public interface ILoyaltyAccrualService
    {
        void Accrue(RentalAgreement agreement);
    }
}