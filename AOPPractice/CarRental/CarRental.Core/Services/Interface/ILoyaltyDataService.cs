using System;

namespace CarRental.Core.Services.Interface
{
    public interface ILoyaltyDataService
    {
        void AddPoints(Guid customerId,int points);
        void SubstractPoints(Guid customerId, int points);
    }
}