using Ch08_EF6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Transactions;
namespace Ch08_EF6
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("List of products that cost more than a given price with most expensive first.");
            string input;
            decimal price;
            do
            {
                Write("Enter a product price: ");
                input = ReadLine();
            } while (!decimal.TryParse(input, out price));
            var options = new TransactionOptions
            {
                Timeout = TimeSpan.FromSeconds(10),
                IsolationLevel=IsolationLevel.ReadCommitted
            };
           // var trans = new TransactionScope(TransactionScopeOption.Required, options)
            using (var db = new NorthWind())
            {

                //db.Database.Connection.Open();
                db.Database.Log = new Action<string>(msg => WriteLine(msg));
                IQueryable<Products> query = db.Products
                    .Where(product => product.UnitPrice > price)
                    .OrderByDescending(product => product.UnitPrice);
                //WriteLine(query.ToString());
                foreach (Products item in query)
                {
                    WriteLine($"{item.ProductID}: {item.ProductName} costs {item.UnitPrice:$#,##0.00}");
                }
                //db.Database.Connection.Close();
            }

            Read();
        }
    }
}
