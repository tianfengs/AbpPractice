using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Core.Entities;
using CarRental.Core.Services.Impl;

namespace CarRental.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("模拟累积");
            SimulateAddingPoints();//模拟累积
            Console.WriteLine("***************");
            Console.WriteLine("模拟兑换");
            SimulateRemovingPoints();//模拟兑换
            Console.Read();
        }

        /// <summary>
        /// 模拟累积积分
        /// </summary>
        static void SimulateAddingPoints()
        {
            var dataService=new FakeLoyalDataService();//这里使用的数据库服务是伪造的
            var service=new LoyaltyAccrualService(dataService);
            var agreement=new RentalAgreement
            {
                Customer = new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "tkb至简",
                    DateOfBirth = new DateTime(2000,1,1),
                    DriversLicense = "123456"
                },
                Vehicle = new Vehicle
                {
                    Id = Guid.NewGuid(),
                    Make = "Ford",
                    Model = "金牛座",
                    Size = Size.Compact,
                    Vin = "浙-ABC123"
                },
                StartDate = DateTime.Now.AddDays(-3),
                EndDate = DateTime.Now
            };
            service.Accrue(agreement);
        }

        /// <summary>
        /// 模拟兑换积分
        /// </summary>
        static void SimulateRemovingPoints()
        {
            var dataService = new FakeLoyalDataService();
            var service = new LoyalRedemptionService(dataService);
            var invoice = new Invoice
            {
                Customer = new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "Farb",
                    DateOfBirth = new DateTime(1999, 1, 1),
                    DriversLicense = "abcdef"
                },
                Vehicle = new Vehicle
                {
                    Id = Guid.NewGuid(),
                    Make = "奥迪",
                    Model = "Q7",
                    Size = Size.Compact,
                    Vin = "浙-DEF123"
                },
                 CostPerDay = 100m,
                 Id = Guid.NewGuid()
            };
            service.Redeem(invoice,3);//这里兑换3天
        }
    }
}
