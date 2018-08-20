using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using CarRental.Core.Entities;
using CarRental.Core.Services.Common;
using CarRental.Core.Services.Interface;

namespace CarRental.Core.Services.Impl
{
    public class LoyaltyAccrualService:ILoyaltyAccrualService
    {
        private readonly ILoyaltyDataService _loyaltyDataService;

        public LoyaltyAccrualService(ILoyaltyDataService loyaltyDataService)
        {
            _loyaltyDataService = loyaltyDataService;//数据服务必须在该对象初始化时传入该对象
        }
        /// <summary>
        /// 该方法包含了积分系统累积客户积分的逻辑和规则
        /// </summary>
        /// <param name="agreement">租赁协议实体</param>
        public void Accrue(RentalAgreement agreement)
        {
            //防御性编程
            if (agreement==null)
            {
                throw new Exception("agreement为null！");
            }
            //日志
            Console.WriteLine("Accrue:{0}",DateTime.Now);
            Console.WriteLine("Customer:{0}",agreement.Customer.Id);
            Console.WriteLine("Vehicle:{0}",agreement.Vehicle.Id);
            try
            {
                using (var ts = new TransactionScope())//开始一个新事务
                {
                    var retries = 3;//重试事务3次
                    var succeeded = false;
                    while (!succeeded)//一直循环，直到成功
                    {
                        try
                        {
                            var rentalTimeSpan = agreement.EndDate.Subtract(agreement.StartDate);
                            var numberOfDays = (int)rentalTimeSpan.TotalDays;
                            var pointsPerDay = 1;
                            if (agreement.Vehicle.Size >= Size.Luxury)
                            {
                                pointsPerDay = 2;
                            }
                            var points = numberOfDays * pointsPerDay;
                            //调用数据服务存储客户获得的积分
                            _loyaltyDataService.AddPoints(agreement.Customer.Id, points);
                            ts.Complete();//调用Complete方法表明事务成功提交
                            succeeded = true;//成功后设置为true，确保最后一次循环迭代
                            Console.WriteLine("Accrue Complete：{0}", DateTime.Now);//这句移入try里
                        }
                        catch
                        {
                            if (retries >= 0)
                            {
                                retries--;//直到尝试完次数时才重抛异常
                            }
                            else
                            {
                                throw;//没有调用Complete方法，事务会回滚
                            }

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                if (!ExceptionHelper.Handle(ex))//如果没有处理异常，继续重抛
                {
                    throw ex;
                }
            }
          
        }
    }
}
