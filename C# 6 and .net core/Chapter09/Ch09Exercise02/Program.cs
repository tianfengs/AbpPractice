using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace Ch09Exercise02
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new NorthwindContext();
            var cities = db.Customers.Select(c => c.City).Distinct();
            QueryCompany(db, cities);
            WriteLine("是否还想查询？y/n?");

            while (ReadLine().ToLower() == "y")
            {
                QueryCompany(db, cities);
                WriteLine("是否还想查询？y/n?");
            }

            Read();
        }

        private static void QueryCompany(NorthwindContext db, IQueryable<string> cities)
        {
            foreach (var city in cities)
            {
                WriteLine($"{city}");
            }
            WriteLine("请输入上面列表中的一个城市名：");
            string cityName = ReadLine();
            while (!cities.Contains(cityName))
            {
                WriteLine("请输入上面列表中的一个城市名：");
                cityName = ReadLine();
            }
            var customers = db.Customers.Where(c => c.City.Equals(cityName));
            WriteLine($"该城市总共有{customers.Count()}个客户,这些客户的公司名称分别是：");
            foreach (var customer in customers)
            {
                WriteLine(customer.CompanyName);
            }
        }
    }
}
