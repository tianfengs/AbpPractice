using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Core.Entities;
using CarRental.Core.Services.Interface;

namespace CarRental.Core.Services.Impl
{
    public class LoyalRedemptionServiceRefactored:ILoyaltyRedemptionService
    {
        private readonly ILoyaltyDataService _loyaltyDataService;
        private readonly IExceptionHandler _exceptionHandler;//异常处理接口
        private readonly ITransactionManager _transactionManager;//事务管理者

        public LoyalRedemptionServiceRefactored(ILoyaltyDataService loyaltyDataService, IExceptionHandler exceptionHandler, 
            ITransactionManager transactionManager)
        {
            _loyaltyDataService = loyaltyDataService;
            _exceptionHandler = exceptionHandler;//通过依赖注入传入
            _transactionManager = transactionManager;
        }

        public void Redeem(Invoice invoice, int numberOfDays)
        {
            //防御性编程
            if (invoice==null)
            {
                throw new Exception("Invoice为null了！");
            }
            if (numberOfDays<=0)
            {
                throw new Exception("numberOfDays不能小于1！");
            }
            //logging
            Console.WriteLine("Redeem: {0}", DateTime.Now);
            Console.WriteLine("Invoice: {0}", invoice.Id);

            _exceptionHandler.Wrapper(() =>
            {
                _transactionManager.Wrapper(() =>
                {
                    var pointsPerDay = 10;
                    if (invoice.Vehicle.Size>=Size.Luxury)
                    {
                        pointsPerDay = 15;
                    }
                    var totalPoints = numberOfDays*pointsPerDay;
                    _loyaltyDataService.SubstractPoints(invoice.Customer.Id,totalPoints);
                    invoice.Discount = numberOfDays*invoice.CostPerDay;
                    // logging
                    Console.WriteLine("Redeem complete: {0}",DateTime.Now);
                });
            });
        }
    }
}
