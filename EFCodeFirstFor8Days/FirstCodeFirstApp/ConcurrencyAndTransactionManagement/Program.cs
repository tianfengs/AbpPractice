using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ConcurrencyAndTransactionManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (var db = new Context())
            //{
            //    db.Database.CreateIfNotExists();
            //}
            Database.SetInitializer(new Initializer());

            #region 1.0  EF的默认并发
            //Database.SetInitializer<Context>(null);
            ////1.用户甲获取id=1的打赏者
            //var donator1 = GetDonator(1);
            ////2.用户乙也获取id=1的打赏者
            //var donator2 = GetDonator(1);
            ////3.用户甲只更新这个实体的Name字段
            //donator1.Name = "用户甲";
            //UpdateDonator(donator1);
            ////4.用户乙只更新这个实体的Amount字段
            //donator2.Amount = 100m;
            //UpdateDonator(donator2); 
            #endregion

            #region 2.0   设计处理字段级别的并发应用
            // //1.用户甲读取id=1的打赏者
            // var donator1 = GetDonator(1);
            // //2.用户乙同样读取id=1的打赏者
            // var donator2 = GetDonator(1);
            // //3.用户甲通过创建一个新的对象来更新打赏金额为100m
            // var newDonator1 = GetUpdatedDonator(donator2.Id, donator1.Name,100m, donator1.DonateDate);
            //UpdateDonatorEnhanced(donator1,newDonator1);
            // //4.用户乙通过创建一个新的对象来更新打赏者姓名为“并发测试”

            // var newDonator2 = GetUpdatedDonator(donator2.Id, "并发测试", donator2.Amount, donator2.DonateDate);
            // UpdateDonatorEnhanced(donator1, newDonator2);
            #endregion

            #region 3.0  为并发实现RowVersion

            ////1.用户甲获取id=1的打赏者
            //var donator1 = GetDonator(1);
            ////2.用户乙也获取id=1的打赏者
            //var donator2 = GetDonator(1);
            ////3.用户甲只更新这个实体的Name字段
            //donator1.Name = "用户甲";
            //UpdateDonator(donator1);
            ////4.用户乙只更新这个实体的Amount字段
            //try
            //{
            //    donator2.Amount = 100m;
            //    UpdateDonator(donator2);
            //    Console.WriteLine("应该发生并发异常！");
            //}
            //catch (DbUpdateConcurrencyException ex)
            //{
            //    Console.WriteLine("异常如愿发生！");
            //}

            #endregion

            #region 4.0 EF默认的事务处理

            //int outputId = 2,inputId=1;
            //decimal transferAmount = 1000m;
            //using (var db=new Context())
            //{
            //    //1 检索事务中涉及的账户
            //    var outputAccount = db.OutputAccounts.Find(outputId);
            //    var inputAccount = db.InputAccounts.Find(inputId);
            //    //2 从输出账户上扣除1000
            //    outputAccount.Balance -= transferAmount;
            //    //3 从输入账户上增加1000
            //    inputAccount.Balance += transferAmount;

            //    //4 提交事务
            //    db.SaveChanges();
            //}
            #endregion

            #region 5.0  使用TransactionScope处理事务
            //int outputId = 2, inputId = 1;
            //decimal transferAmount = 1000m;
            //using (var ts=new TransactionScope(TransactionScopeOption.Required))
            //{
            //    var db1=new Context();
            //    var db2=new Context();
            //    //1 检索事务中涉及的账户
            //    var outputAccount = db1.OutputAccounts.Find(outputId);
            //    var inputAccount = db2.InputAccounts.Find(inputId);
            //    //2 从输出账户上扣除1000
            //    outputAccount.Balance -= transferAmount;
            //    //3 从输入账户上增加1000
            //    inputAccount.Balance += transferAmount;

            //    db1.SaveChanges();
            //    db2.SaveChanges();

            //    ts.Complete();
            //}
            #endregion

            #region 6.0 使用EF6管理事务
            //int outputId = 2, inputId = 1;
            //decimal transferAmount = 1000m;
            //using (var db=new Context())
            //{
            //    using (var trans=db.Database.BeginTransaction())
            //    {
            //        try
            //        {
            //            var sql = "Update OutputAccounts set Balance=Balance-@amountToDebit where id=@outputId";
            //            db.Database.ExecuteSqlCommand(sql, new SqlParameter("@amountToDebit", transferAmount), new SqlParameter("@outputId",outputId));

            //            var inputAccount = db.InputAccounts.Find(inputId);
            //            inputAccount.Balance += transferAmount;
            //            db.SaveChanges();

            //            trans.Commit();
            //        }
            //        catch (Exception ex)
            //        {
            //            trans.Rollback();
            //        }
            //    }
            //}
            #endregion

            #region 7.0 使用已存在的事务
            int outputId = 2, inputId = 1;
            decimal transferAmount = 1000m;
            var connectionString = ConfigurationManager.ConnectionStrings["ConcurrencyAndTransactionManagementConn"].ConnectionString;
            using (var conn=new SqlConnection(connectionString))
            {
                conn.Open();
                using (var trans=conn.BeginTransaction())
                {
                    try
                    {
                        var result = DebitOutputAccount(conn, trans, outputId, transferAmount);
                        if (!result)
                        {
                            throw new Exception("不能正常扣款！");
                        }
                        using (var db=new Context(conn,contextOwnsConnection:false))
                        {
                            db.Database.UseTransaction(trans);
                            var inputAccount=db.InputAccounts.Find(inputId);
                            inputAccount.Balance += transferAmount;
                            db.SaveChanges();
                        }
                        trans.Commit();
                    }
                    catch (Exception ex) 
                    {
                        trans.Rollback();
                    }
                }
            }

            #endregion
            Console.WriteLine("Operation Completed!");
            Console.ReadLine();
        }

        static Donator GetDonator(int id)
        {
            using (var db = new Context())
            {
                return db.Donators.Find(id);
            }
        }

        static void UpdateDonator(Donator donator)
        {
            using (var db = new Context())
            {
                db.Entry(donator).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        static Donator GetUpdatedDonator(int id, string name, decimal amount, DateTime donateDate)
        {
            return new Donator
            {
                Id = id,
                Name = name,
                Amount = amount,
                DonateDate = donateDate
            };
        }

        static void UpdateDonatorEnhanced(Donator originalDonator, Donator newDonator)
        {
            using (var db = new Context())
            {
                //从数据库中检索最新的模型
                var donator = db.Donators.Find(originalDonator.Id);
                //接下来检查用户修改的每个属性
                if (originalDonator.Name != newDonator.Name)
                {
                    //将新值更新到数据库
                    donator.Name = newDonator.Name;
                }
                if (originalDonator.Amount != newDonator.Amount)
                {
                    //将新值更新到数据库
                    donator.Amount = newDonator.Amount;
                }
                //这里省略其他属性...
                db.SaveChanges();
            }
        }

        //模拟老项目的类库
        static bool DebitOutputAccount(SqlConnection conn, SqlTransaction trans, int accountId, decimal amountToDebit)
        {
            int affectedRows = 0;
            var command = conn.CreateCommand();
            command.Transaction = trans;
            command.CommandType=CommandType.Text;
            command.CommandText = "Update OutputAccounts set Balance=Balance-@amountToDebit where id=@accountId";
            command.Parameters.AddRange(new SqlParameter[]
            {
                new SqlParameter("@amountToDebit",amountToDebit), 
                new SqlParameter("@accountId",accountId) 
            });

            try
            {
                affectedRows= command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return affectedRows == 1;
        }
    }
}
