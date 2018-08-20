using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Text;
using System.Threading.Tasks;
using Ch09_JoiningGrouping;

namespace Ch09_JoiningGrouping
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new NorthWind();

            var categories = db.Categories.Select(c => new { c.CategoryID, c.CategoryName }).ToArray();
            var products = db.Products.Select(p => new { p.ProductID, p.ProductName, p.CategoryID }).ToArray();

            // join every product to its category to return 77 matches
            var queryJoin = categories.Join(products,
                category => category.CategoryID,
                product => product.CategoryID,
                (c, p) => new { c.CategoryName, p.ProductName, p.ProductID })
                .OrderBy(cp => cp.ProductID);

            foreach (var item in queryJoin)
            {
                WriteLine($"{item.ProductID}: {item.ProductName} is in {item.CategoryName}.");
            }

            // group all products by their category to return 8 matches
            var queryGroup = categories.GroupJoin(products,
                category => category.CategoryID,
                product => product.CategoryID,
                (c, Products) => new { c.CategoryName, Products = Products.OrderBy(p => p.ProductName) });

            foreach (var item in queryGroup)
            {
                WriteLine($"{item.CategoryName} has {item.Products.Count()} products.");
                foreach (var product in item.Products)
                {
                    WriteLine($"  {product.ProductName}");
                }
            }
            var newCate = new Category()
            {
                CategoryName = "test",
                Description = "test",
            };

            db.Database.Log = (msg => WriteLine(msg));
            var testTime = new Table();
            db.Tables.Add(testTime);
            
             db.Categories.Add(newCate);
            var Id = newCate.CategoryID;//Id=0
            db.SaveChanges();
        }
    }
}
