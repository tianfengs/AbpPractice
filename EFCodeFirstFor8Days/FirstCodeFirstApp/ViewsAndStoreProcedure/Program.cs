using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewsAndStoreProcedure.Model;

namespace ViewsAndStoreProcedure
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 1.0 视图
            Database.SetInitializer(new Initializer());
            using (var db = new DonatorsContext())
            {
                //1.1 方法一
                //var donators = db.DonatorViews;
                //foreach (var donator in donators)
                //{
                //    Console.WriteLine(donator.ProvinceName + "\t" + donator.DonatorId + "\t" + donator.DonatorName + "\t" + donator.Amount + "\t" + donator.DonateDate);
                //}


                //1.2 另一种方法
                var sql = @"SELECT DonatorId ,DonatorName ,Amount ,DonateDate ,ProvinceName from dbo.DonatorViews where ProvinceName={0}";
                var donatorsViaCommand = db.Database.SqlQuery<DonatorViewInfo>(sql,"河北省");
                foreach (var donator in donatorsViaCommand)
                {
                    Console.WriteLine(donator.ProvinceName + "\t" + donator.DonatorId + "\t" + donator.DonatorName + "\t" + donator.Amount + "\t" + donator.DonateDate);
                }


            }

            #endregion


            #region 2.0 EF调用存储过程查询数据SqlQuery

            //using (var db=new DonatorsContext())
            //{
            //    var sql = "SelectDonators {0}";
            //    var donators = db.Database.SqlQuery<DonatorFromStoreProcedure>(sql,"山东省");
            //    foreach (var donator in donators)
            //    {
            //        Console.WriteLine(donator.ProvinceName+"\t"+donator.Name+"\t"+donator.Amount+"\t"+donator.DonateDate);
            //    }
            //}

            //2.1 EF调用存储过程之ExecuteSqlCommand方法
            using (var db = new DonatorsContext())
            {
                //var sql = "UpdateDonator {0},{1}";
                //Console.WriteLine("执行存储过程前的数据为：");
                //PrintDonators();
                //var rowsAffected = db.Database.ExecuteSqlCommand(sql, "Update", 10m);
                //Console.WriteLine("影响的行数为{0}条", rowsAffected);
                //Console.WriteLine("执行存储过程之后的数据为：");
                //PrintDonators();
            }

            #endregion

            #region 3.0 异步API

            //Console.WriteLine(FindDonatorAsync(1).Result.DonateDate);
            #endregion

            Console.WriteLine("Operation Completed!");
            Console.ReadLine();
        }

        #region 3.0 异步API

        //3.1 异步查询对象列表
        static async Task<IEnumerable<Donator>> GetDonatorsAsync()
        {
            using (var db = new DonatorsContext())
            {
                return await db.Donators.ToListAsync();
            }
        }

        //3.2 异步创建一个新的对象
        static async Task InsertDonatorAsync(Donator donator)
        {
            using (var db = new DonatorsContext())
            {
                db.Donators.Add(donator);
                await db.SaveChangesAsync();
            }
        }

        //3.3 异步定位一条记录
        static async Task<Donator> FindDonatorAsync(int donatorId)
        {
            using (var db = new DonatorsContext())
            {
                return await db.Donators.FindAsync(donatorId);
            }
        }

        //3.4 异步聚合函数
        static async Task<int> GetDonatorCountAsync()
        {
            using (var db = new DonatorsContext())
            {
                return await db.Donators.CountAsync();
            }
        }

        //3.5 异步遍历查询结果
        static async Task LoopDonatorsAsync()
        {
            using (var db = new DonatorsContext())
            {
                await db.Donators.ForEachAsync(d =>
                {
                    d.DonateDate = DateTime.Today;
                });
            }
        }
        #endregion
        static void PrintDonators()
        {
            using (var db = new DonatorsContext())
            {
                var donators = db.Donators.Where(p => p.ProvinceId == 2);//找出河北省的打赏者
                foreach (var donator in donators)
                {
                    Console.WriteLine(donator.Name + "\t" + donator.Amount + "\t" + donator.DonateDate);
                }
            }
        }
    }
}
