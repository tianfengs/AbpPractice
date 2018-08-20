using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstCodeFirstApp.NewSample;

namespace FirstCodeFirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new Initializer());
            using (var context = new Context())
            {
                context.Database.CreateIfNotExists();//如果数据库不存在时则创建
                #region 1. 创建记录
                //var donators = new List<Donator>
                //{
                //    new Donator
                //    {
                //      Name   = "陈志康",
                //      Amount = 50,
                //      DonateDate = new DateTime(2016, 4, 7)
                //    },
                //    new Donator
                //    {
                //        Name = "海风",
                //        Amount = 5,
                //        DonateDate = new DateTime(2016, 4, 8)
                //    },
                //    new Donator
                //    {
                //        Name = "醉千秋",
                //        Amount = 18.8m,
                //        DonateDate = new DateTime(2016, 4, 15)
                //    }
                //};

                //context.Donators.AddRange(donators);
                //context.SaveChanges();

                #endregion

                #region 2.0 查询记录

                //var donators = context.Donators;
                //Console.WriteLine("Id\t\t姓名\t\t金额\t\t赞助日期");
                //foreach (var donator in donators)
                //{
                //    Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}", donator.DonatorId,donator.Name, donator.Amount, donator.DonateDate.ToShortDateString());
                //}
                #endregion

                #region 3.0 更新记录

                //var donators = context.Donators;
                //if (donators.Any())
                //{
                //    var toBeUpdatedDonator = donators.First(d => d.Name == "醉千秋");
                //    toBeUpdatedDonator.Name = "醉、千秋";
                //    context.SaveChanges();
                //}

                #endregion

                #region 4.0 删除记录

                //var toBeDeletedDonator = context.Donators.Single(d => d.Name == "待打赏");
                //if (toBeDeletedDonator!=null)
                //{
                //    context.Donators.Remove(toBeDeletedDonator);
                //    context.SaveChanges();
                //}

                #endregion

                #region 5.0 遍历PayWays表

                //var payways = context.PayWays;
                //foreach (var payway in payways)
                //{
                //    Console.WriteLine("Id={0},Name={1}", payway.Id, payway.Name);
                //}

                #endregion

                #region 6.0 一对多关系

                //var donator = new Donator
                //{
                //    Amount = 6,
                //    Name = "键盘里的鼠标",
                //    DonateDate =DateTime.Parse("2016-4-13"),
                //};
                //donator.PayWays.Add(new PayWay{Name = "支付宝"});
                //donator.PayWays.Add(new PayWay{Name = "微信"});
                //context.Donators.Add(donator);
                //context.SaveChanges();

                #endregion

                #region 6.1 一对多关系 例子2

                //var donatorType = new DonatorType
                //{
                //    Name = "博客园园友",
                //    Donators = new List<Donator>
                //    {
                //        new Donator
                //        {
                //            Amount =6,Name = "键盘里的鼠标",DonateDate =DateTime.Parse("2016-4-13"),
                //            PayWays = new List<PayWay>{new PayWay{Name = "支付宝"},new PayWay{Name = "微信"}}
                //        }     
                //    }
                //};
                //var donatorType2 = new DonatorType
                //{
                //    Name = "非博客园园友",
                //    Donators = new List<Donator>
                //    {

                //         new Donator
                //        {
                //            Amount =10,Name = "待赞助",DonateDate =DateTime.Parse("2016-4-27"),
                //            PayWays = new List<PayWay>{new PayWay{Name = "支付宝"},new PayWay{Name = "微信"}}
                //        }

                //    }
                //};
                //context.DonatorTypes.Add(donatorType);
                //context.DonatorTypes.Add(donatorType2);
                //context.SaveChanges();

                #endregion

                #region 7 一对一关系

                //var student = new Student
                //{
                //    CollegeName = "XX大学",
                //    EnrollmentDate = DateTime.Parse("2011-11-11"),
                //    Person = new Person
                //    {
                //        Name = "Farb",
                //    }
                //};

                //context.Students.Add(student);
                //context.SaveChanges();

                #endregion

                #region 8 多对多关系

                var person = new Person
                {
                    Name = "比尔盖茨",
                };
                var person2 = new Person
                {
                    Name = "乔布斯",
                };
                context.People.Add(person);
                context.People.Add(person2);
                var company = new Company
                {
                    CompanyName = "微软"
                };
                company.Persons.Add(person);
                context.Companies.Add(company);
                context.SaveChanges();

                #endregion
            }
            // Console.Write("DB has Created!");//提示DB创建成功
            //Console.Write("Creation Finished!");//提示创建完成
            //Console.Write("Query Finished!");//提示查询完成
            //Console.Write("Update Finished!");//提示更新完成
            //Console.Write("Delete Finished!");//提示删除完成
            Console.WriteLine("success");
            Console.Read();
        }
    }
}
