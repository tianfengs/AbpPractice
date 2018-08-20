using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Console;

namespace Ch09_LINQandXML
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new NorthWindContext();
            var products = db.Products.ToArray();
            var xml = new XElement("products", products.Select(p =>
             new XElement("product",
                 new XAttribute("id", p.ProductID),
                 new XAttribute("price", p.UnitPrice),
                 new XElement("name", p.ProductName)

                 )));

            WriteLine(xml.ToString());

            XDocument doc = XDocument.Load("Ch09_LINQandXML.exe.config");
            var appsettings = doc.Descendants("appSettings").Descendants("add")//区分大小写
                    .Select(node => new
                    {
                        Key = node.Attribute("key").Value,
                        value = node.Attribute("value").Value
                    }).ToArray();

            foreach (var item in appsettings)
            {
                WriteLine($"{item.Key}={item.value}");
            }
            WriteLine(default(DateTime));
            Read();
        }
    }
}
