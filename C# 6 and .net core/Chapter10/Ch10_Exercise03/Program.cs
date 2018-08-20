using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization.Formatters.Soap;
using System.Web.Script.Serialization;

namespace Ch10_Exercise03
{
    class Program
    {
        static void Main(string[] args)
        {
            string dir = @"dir\";
            Directory.CreateDirectory(dir);
            try
            {
                var db = new NorthWindsContext();
                db.Configuration.ProxyCreationEnabled = false;
                DbQuery<Category> query= db.Categories.Include("Products");
                // create a local in-memory copy of the categories and related products
                Category[] results = query.ToArray();

                // 1. XmlSerializer
                string xmlfile = dir + "CategoriesAndProductsXS.xml";
                var xmlSerializer = new XmlSerializer(typeof(Category[]));
                using (TextWriter tw= File.CreateText(xmlfile))
                {
                    xmlSerializer.Serialize(tw, results);
                }
                WriteLine($"xml文件大小：{new FileInfo(xmlfile).Length}字节");

                //反序列化
                //using (TextReader tr = File.OpenText(xmlfile))
                //{
                //    Category[] cates = xmlSerializer.Deserialize(tr) as Category[];
                //    foreach (var item in cates)
                //    {
                //        WriteLine($"{item.CategoryID,3}----{item.CategoryName,-15}————有{item.Products.Count,2}个产品");
                //    }
                //}

                // 2. DataContractSerializer
                string dcsfile = dir + "CategoriesAndProductsDCS.xml";
                var dcsSerializer = new DataContractSerializer(typeof(Category[]));
                using (XmlWriter xw=XmlWriter.Create(dcsfile))
                {
                    dcsSerializer.WriteObject(xw, results);
                }
                WriteLine($"DCSxml文件大小：{new FileInfo(dcsfile).Length}字节");

                //using (XmlReader xr=XmlReader.Create(dcsfile))
                //{
                //    Category[] cates = dcsSerializer.ReadObject(xr, false) as Category[];
                //    foreach (var item in cates)
                //    {
                //        WriteLine($"{item.CategoryID,3}----{item.CategoryName,-15}————有{item.Products.Count,2}个产品");
                //    }
                //}

                // 3. DataContractJsonSerializer
                string jsonfile = dir + "CategoriesAndProductsDCS.json";
                var jsonSer = new DataContractJsonSerializer(typeof(Category[]));
                using (FileStream fs=File.Create(jsonfile))
                {
                    jsonSer.WriteObject(fs, results);
                }
                WriteLine($"jsonfile文件大小：{new FileInfo(jsonfile).Length}字节");

                //using (var fs=File.OpenRead(jsonfile))
                //{
                //    var cates= jsonSer.ReadObject(fs) as Category[];
                //    foreach (var item in cates)
                //    {
                //        WriteLine($"{item.CategoryID,3}----{item.CategoryName,-15}————有{item.Products.Count,2}个产品");
                //    }
                //}


                // 4. BinaryFormatter
                string filenameBF = dir + "CategoriesAndProducts.bin";
                var bfSer = new BinaryFormatter();
                using (var fs = File.Create(filenameBF))
                {
                    bfSer.Serialize(fs, results);
                }
                WriteLine($"CategoriesAndProducts.bin文件大小：{new FileInfo(filenameBF).Length}字节");

                // 5. SoapFormatter cannot serialize generic types!
                //string filesoap = dir + "CategoriesAndProducts.soap";
                //var spSer = new SoapFormatter();
                //using (var fs=File.Create(filesoap))
                //{
                //    spSer.Serialize(fs, results);
                //}
                //WriteLine($"CategoriesAndProducts.soap文件大小：{new FileInfo(filesoap).Length}字节");

                //6.JavascriptSerializer
                string jssFile = dir + "CategoriesAndProducts.json";
                var jss = new JavaScriptSerializer();
                using (var fs=File.Create(jssFile))
                {
                    using (var sw=new StreamWriter(fs))
                    {
                        string str = jss.Serialize(results);
                        sw.Write(str);
                    }
                    
                }
                WriteLine($"CategoriesAndProducts.json文件大小：{new FileInfo(jssFile).Length}字节");
            }
            catch (Exception ex)
            {
                WriteLine($"{ex.GetType()}:{ex.Message}");
            }

        }
    }
}
