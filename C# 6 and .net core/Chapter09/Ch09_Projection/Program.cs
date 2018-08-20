using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Text;
using System.Threading.Tasks;

namespace Ch09_Projection
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new Northwind();

            var query = db.Products
                .Where(product => product.UnitPrice < 10M)
                .OrderByDescending(product => product.UnitPrice)
                .Select(p=>new { p.ProductID,p.ProductName,p.UnitPrice});
            WriteLine(query.ToString());

            foreach (var item in query)
            {
                WriteLine($"{item.ProductID}: {item.ProductName} costs {item.UnitPrice:$#,##0.00}");
            }

            Read();
        }
    }
}
