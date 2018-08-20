using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static System.Console;

namespace Ch08_EFCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var db = new Northwind();
            var query = db.Categories.Include(c => c.Products);

            foreach (var item in query)
            {
                WriteLine($"{item.CategoryName} has {item.Products.Count} products.");
            }

            Read();
        }
    }
}
