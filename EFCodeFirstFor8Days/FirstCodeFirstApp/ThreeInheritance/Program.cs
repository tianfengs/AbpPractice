using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new Initializer());
            using (var context = new Context())
            {
                #region 1.0  TPT继承

                //var employee = new Employee
                //{
                //    Name = "farb",
                //    Email = "farbguo@qq.com",
                //    PhoneNumber = "12345678",
                //    Salary = 1234m
                //};

                //var vendor = new Vendor
                //{
                //    Name = "tkb至简",
                //    Email = "farbguo@outlook.com",
                //    PhoneNumber = "78956131",
                //    HourlyRate = 4567m
                //};

                //context.People.Add(employee);
                //context.People.Add(vendor);
                //context.SaveChanges();
                #endregion


                #region 2.0 TPH 继承
                 //var employee = new Employee
                 //{
                 //    Name = "farb",
                 //    Email = "farbguo@qq.com",
                 //    PhoneNumber = "12345678",
                 //    Salary = 1234m
                 //};
                
                 //var vendor = new Vendor
                 //{
                 //    Name = "tkb至简",
                 //    Email = "farbguo@outlook.com",
                 //    PhoneNumber = "78956131",
                 //    HourlyRate = 4567m
                 //};
                
                 //context.Person.Add(employee);
                 //context.Person.Add(vendor);
                 //context.SaveChanges();
                #endregion

                #region 3.0 TPC 继承
                var employee = new Employee
                {
                    Name = "farb",
                    Email = "farbguo@qq.com",
                    PhoneNumber = "12345678",
                    Salary = 1234m
                };

                var vendor = new Vendor
                {
                    Name = "tkb至简",
                    Email = "farbguo@outlook.com",
                    PhoneNumber = "78956131",
                    HourlyRate = 4567m
                };

                context.People.Add(employee);
                context.People.Add(vendor);
                context.SaveChanges();
                #endregion
            }
            Console.WriteLine("Success!");
            Console.Read();
        }
    }
}
