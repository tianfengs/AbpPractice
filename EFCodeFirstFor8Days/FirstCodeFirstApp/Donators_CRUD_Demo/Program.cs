using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donators_CRUD_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DonatorsContext>());
            using (var db = new DonatorsContext())
            {

                #region 1.0 简单的查询演示
                //1 查询语法
                //var donators = from donator in db.Donators
                //    where donator.Amount == 50m
                //    select donator;

                //2 方法语法
                //var donators = db.Donators.Where(d => d.Amount == 50m); 
                #endregion

                #region 2.0 使用导航属性
                //1 查询语法
                //var donators = from province in db.Provinces
                //               where province.ProvinceName == "山东省"
                //               from donator in province.Donators
                //               select donator;

                //2 方法语法
                //var donators = db.Provinces.Where(p => p.ProvinceName == "山东省").SelectMany(p => p.Donators);
                //Console.WriteLine(donators);
                //1 查询语法
                //var province = from donator in db.Donators
                //    where donator.Name == "雪茄"
                //    select donator.Province;

                //2 方法语法
                //var province = db.Donators.Where(d => d.Name == "雪茄").Select(d => d.Province);

                //Console.WriteLine(province);

                #endregion

                #region 3.0 过滤数据

                //1 查询语法
                //var donators = from donator in db.Donators
                //               where donator.Amount > 10 && donator.Amount < 20
                //               select donator;

                //2 方法语法
                //var donators = db.Donators.Where(d => d.Amount > 10 && d.Amount < 20);
                #endregion

                #region 4.0 LINQ投影

                //1 查询语法
                //var donators = from province in db.Provinces
                //               select new
                //               {
                //                   Province=province.ProvinceName,
                //                   DonatorList=province.Donators
                //               };

                //2 方法语法
                //var donators =db.Provinces.Select(p=>new
                //{
                //    Province = p.ProvinceName,
                //    DonatorList = p.Donators
                //});

                //3 返回一个对象的方法语法
                //var donators = db.Provinces.Select(p => new DonatorsWithProvinceViewModel
                //{
                //    Province = p.ProvinceName,
                //    DonatorList = p.Donators
                //});
                //Console.WriteLine("省份\t打赏者");
                //foreach (var donator in donators)
                //{
                //    foreach (var donator1 in donator.DonatorList)
                //    {
                //        Console.WriteLine("{0}\t{1}", donator.Province,donator1.Name); 
                //    }

                //}
                #endregion

                #region 5.0 分组Group
                //1 查询语法
                //var donatorsWithProvince = from donator in db.Donators
                //    group donator by donator.Province.ProvinceName
                //    into donatorGroup
                //    select new
                //    {
                //        ProvinceName=donatorGroup.Key,
                //        Donators=donatorGroup
                //    };

                //2 方法语法
                //var donatorsWithProvince = db.Donators.GroupBy(d => d.Province.ProvinceName)
                //    .Select(donatorGroup => new
                //    {
                //        ProvinceName = donatorGroup.Key,
                //        Donators = donatorGroup
                //    });
                //foreach (var dwp in donatorsWithProvince)
                //{
                //    Console.WriteLine("{0}的打赏者如下：",dwp.ProvinceName);
                //    foreach (var d in dwp.Donators)
                //    {
                //        Console.WriteLine("{0}\t\t{1}", d.Name, d.Amount);
                //    }
                //}
                #endregion

                #region 6.0 排序Ordering
                //1 升序查询语法
                //var donators = from donator in db.Donators
                //               orderby donator.Amount ascending //ascending可省略
                //               select donator;

                //2 升序方法语法
                //var donators = db.Donators.OrderBy(d => d.Amount);
                //#endregion

                //1 降序查询语法
                //var donators = from donator in db.Donators
                //               orderby donator.Amount descending 
                //               select donator;

                //2 降序方法语法
                //var donators = db.Donators.OrderByDescending(d => d.Amount);
                #endregion

                #region 7.0 聚合操作

                //var count = (from donator in db.Donators
                //    where donator.Province.ProvinceName == "山东省"
                //    select donator).Count();

                //var count2 = db.Donators.Count(d => d.Province.ProvinceName == "山东省");
                //Console.WriteLine("查询语法Count={0}，方法语法Count={1}",count,count2);

                //var sum = db.Donators.Sum(d => d.Amount);//计算所有打赏者的金额总和
                //var min = db.Donators.Min(d => d.Amount);//最少的打赏金额
                //var max = db.Donators.Max(d => d.Amount);//最多的打赏金额
                //var average = db.Donators.Average(d => d.Amount);//打赏金额的平均值

                //Console.WriteLine("Sum={0},Min={1},Max={2},Average={3}",sum,min,max,average);
                #endregion


                #region 8.0 分页Paging

                //var donatorsBefore = db.Donators;
                //var donatorsAfter = db.Donators.OrderBy(d => d.Id).Skip(2);
                //Console.WriteLine("原始数据打印结果：");
                //PrintDonators(donatorsBefore);
                //Console.WriteLine("Skip(2)之后的结果：");
                //PrintDonators(donatorsAfter);

                //var take = db.Donators.Take(3);
                //Console.WriteLine("Take(3)之后的结果：");
                //PrintDonators(take);

                //分页实现
                //while (true)
                //{
                //    Console.WriteLine("您要看第几页数据");
                //    string pageStr = Console.ReadLine() ?? "1";
                //    int page = int.Parse(pageStr);
                //    const int pageSize = 2;
                //    if (page>0&&page<4)
                //    {
                //        var donators = db.Donators.OrderBy(d => d.Id).Skip((page - 1)*pageSize).Take(pageSize);
                //        PrintDonators(donators);
                //    }
                //    else
                //    {
                //        break;
                //    }
                //}

                #endregion

                #region 9.0实现多表连接

                //var join1 = from province in db.Provinces
                //            join donator in db.Donators on province.Id equals donator.Province.Id
                //            into donatorList//注意，这里的donatorList是属于某个省份的所有打赏者，很多人会误解为这是两张表join之后的结果集
                //            select new
                //            {
                //                ProvinceName = province.ProvinceName,
                //                DonatorList = donatorList
                //            };

                //var join2 = db.Provinces.GroupJoin(db.Donators,//Provinces集合要连接的Donators实体集合
                //    province => province.Id,//左表要连接的键
                //    donator => donator.Province.Id,//右表要连接的键
                //    (province, donatorGroup) => new//返回的结果集
                //    {
                //        ProvinceName = province.ProvinceName,
                //        DonatorList = donatorGroup
                //    }
                //    );
                #endregion

                #region 10.0 懒加载和预加载

                //var donators = db.Donators;//还没有查询数据库
                //var donatorList = donators.ToList();//已经查询了数据库，但由于懒加载的存在，还没有加载Provinces表的数据
                //var province = donatorList.ElementAt(0).Province;//因为用户访问了Province表的数据，因此这时才加载

                //预加载
                //var donators2 = db.Donators.Include(d => d.Province).ToList();
                //var donators3 = db.Donators.Include("Provinces").ToList();

                #endregion


                //Console.WriteLine("Id\t\t姓名\t\t金额\t\t打赏日期");
                //foreach (var donator in donators)
                //{
                //    Console.WriteLine("{0,-10}\t{1,-10}\t{2,-10}\t{3,-10}", donator.Id, donator.Name, donator.Amount, donator.DonateDate.ToShortDateString());
                //}
            }

            #region 11.0 插入数据

            //方法一
            //var province = new Province { ProvinceName = "浙江省" };
            //province.Donators.Add(new Donator
            //{
            //    Name = "星空夜焰",
            //    Amount = 50m,
            //    DonateDate = DateTime.Parse("2016-5-30")
            //});

            //province.Donators.Add(new Donator
            //{
            //    Name = "伟涛",
            //    Amount = 25m,
            //    DonateDate = DateTime.Parse("2016-5-25")
            //});

            //using (var db=new DonatorsContext())
            //{
            //    db.Provinces.Add(province);
            //    db.SaveChanges();
            //}

            //方法二：直接设置对象的状态
            //var province2 = new Province{ ProvinceName = "广东省"};
            //province2.Donators.Add(new Donator
            //{
            //    Name = "邱宇",
            //    Amount = 30,
            //    DonateDate = DateTime.Parse("2016-04-25")
            //});
            //using (var db=new DonatorsContext())
            //{
            //    db.Entry(province2).State=EntityState.Added;
            //    db.SaveChanges();
            //}
            #endregion

            #region 12.0 更新数据

            //using (var db = new DonatorsContext())
            //{
            //    var donator = db.Donators.Find(3);
            //    donator.Name = "醉千秋";//我想把“醉、千秋”中的顿号去掉
            //    db.SaveChanges();
            //}

            //var province = new Province { Id = 1, ProvinceName = "山东省" };
            //province.Donators.Add(new Donator
            //{
            //    Name = "醉、千秋",//再改回来
            //    Id = 3,
            //    Amount = 12.00m,
            //    DonateDate = DateTime.Parse("2016/4/13 0:00:00"),
            //});

            //using (var db = new DonatorsContext())
            //{
            //    db.Entry(province).State = EntityState.Modified;
            //    foreach (var donator in province.Donators)
            //    {
            //        db.Entry(donator).State = EntityState.Modified;
            //    }
            //    db.SaveChanges();
            //}

            //using (var db=new DonatorsContext())
            //{
            //    var provinceNormal = db.Provinces.Include(p => p.Donators);

            //    foreach (var p in provinceNormal)
            //    {
            //        Console.WriteLine("省份的追踪状态：{0}", db.Entry(p).State);
            //        foreach (var donator in p.Donators)
            //        {
            //            Console.WriteLine("打赏者的追踪状态：{0}", db.Entry(donator).State);
            //        }
            //        Console.WriteLine("**************");
            //    }
            //    var province = db.Provinces.Include(p => p.Donators).AsNoTracking();//使用AsNoTracking()方法设置不再追踪该实体
            //    Console.WriteLine("使用了AsNoTracking()方法之后");
            //    foreach (var p in province)
            //    {
            //        Console.WriteLine("省份的追踪状态：{0}", db.Entry(p).State);
            //        foreach (var donator in p.Donators)
            //        {
            //            Console.WriteLine("打赏者的追踪状态：{0}",db.Entry(donator).State);
            //        }
            //        Console.WriteLine("**************");
            //    }
            //}

            //var donator = new Donator
            //{
            //    Id = 4,
            //    Name = "雪茄",
            //    Amount = 18.80m,
            //    DonateDate = DateTime.Parse("2016/4/15 0:00:00")
            //};
            //using (var db = new DonatorsContext())
            //{
            //    db.Donators.Attach(donator);
            //    //db.Entry(donator).State=EntityState.Modified;//这句可以作为第二种方法替换上面一句代码
            //    donator.Name = "秦皇岛-雪茄";
            //    db.SaveChanges();
            //}

            #endregion

            #region 13.0 删除数据

            //方法1：常规删除
            //using (var db = new DonatorsContext())
            //{
            //    PrintAllDonators(db);

            //    Console.WriteLine("删除后的数据如下：");
            //    var toDelete = db.Provinces.Find(2);
            //    toDelete.Donators.ToList().ForEach(
            //        d => db.Donators.Remove(d));
            //    db.Provinces.Remove(toDelete);
            //    db.SaveChanges();

            //    PrintAllDonators(db);
            //}

            //方法2：通过设置实体状态删除
            //var toDeleteProvince = new Province { Id = 1 };//id=1的省份是山东省，对应三个打赏者
            //toDeleteProvince.Donators.Add(new Donator
            //{
            //    Id = 1
            //});
            //toDeleteProvince.Donators.Add(new Donator
            //{
            //    Id = 2
            //});
            //toDeleteProvince.Donators.Add(new Donator
            //{
            //    Id = 3
            //});

            //using (var db = new DonatorsContext())
            //{
            //    PrintAllDonators(db);//删除前先输出现有的数据,不能写在下面的using语句中，否则Attach方法会报错，原因我相信你已经可以思考出来了
            //}
           
            //using (var db = new DonatorsContext())
            //{
            //    db.Provinces.Attach(toDeleteProvince);
            //    foreach (var donator in toDeleteProvince.Donators.ToList())
            //    {
            //        db.Entry(donator).State=EntityState.Deleted;
            //    }
            //    db.Entry(toDeleteProvince).State=EntityState.Deleted;//删除完子实体再删除父实体
            //    db.SaveChanges();
            //    Console.WriteLine("删除之后的数据如下：\r\n");
            //    PrintAllDonators(db);//删除后输出现有的数据
            //}
            #endregion

            #region 14.0 使用内存数据

            using (var db=new DonatorsContext())
            {
                //14.1 证明Find方法先去内存中寻找数据
                var provinces = db.Provinces.ToList();
                //var query = db.Provinces.Find(3);//还剩Id=3和4的两条数据了

                //14.2 ChangeTracker的使用
                foreach (var dbEntityEntry in db.ChangeTracker.Entries<Province>())
                {
                    Console.WriteLine(dbEntityEntry.State);
                    Console.WriteLine(dbEntityEntry.Entity.ProvinceName);
                }
            }
            #endregion

            Console.WriteLine("Operation completed!");
            Console.Read();
        }

        //输出所有的打赏者
        private static void PrintAllDonators(DonatorsContext db)
        {
            var provinces = db.Provinces.ToList();
            foreach (var province in provinces)
            {
                Console.WriteLine("{0}的打赏者如下：", province.ProvinceName);
                foreach (var donator in province.Donators)
                {
                    Console.WriteLine("{0,-10}\t{1,-10}\t{2,-10}\t{3,-10}", donator.Id, donator.Name, donator.Amount,
                        donator.DonateDate.ToShortDateString());
                }
            }
        }

        static void PrintDonators(IQueryable<Donator> donators)
        {
            Console.WriteLine("Id\t\t姓名\t\t金额\t\t打赏日期");
            foreach (var donator in donators)
            {
                Console.WriteLine("{0,-10}\t{1,-10}\t{2,-10}\t{3,-10}", donator.Id, donator.Name, donator.Amount, donator.DonateDate.ToShortDateString());
            }
        }


    }
}
