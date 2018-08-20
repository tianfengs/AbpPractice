using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Xml.Serialization;
using System.IO;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
namespace Ch10_Serialization
{
    class Program
    {
        static void Main(string[] args)
        {

            // create an object graph
            var people = new List<Person>
            {
                new Person(30000M) { FirstName = "Alice", LastName = "Smith", DateOfBirth = new DateTime(1974, 3, 14) },
                new Person(40000M) { FirstName = "Bob", LastName = "Jones", DateOfBirth = new DateTime(1969, 11, 23) },
                new Person(20000M) { FirstName = "Charlie", LastName = "Rose", DateOfBirth = new DateTime(1964, 5, 4), Children = new HashSet<Person>
                    { new Person(0M) { FirstName = "Sally", LastName = "Rose", DateOfBirth = new DateTime(1990, 7, 12) } } }
             };

            // create a file to write to
            string xmlFilepath = @"C:\Code\Ch10_People.xml";
            using (FileStream fs= File.Create(xmlFilepath))
            {
                // create an object that will format a List of Persons as XML
                var xmlSerializer = new XmlSerializer(typeof(List<Person>));
                xmlSerializer.Serialize(fs, people);
                WriteLine($"{xmlFilepath}的文件大小是{new FileInfo(xmlFilepath).Length}字节");

            }
            WriteLine(File.ReadAllText(xmlFilepath));

            using (FileStream fs=File.Open(xmlFilepath,FileMode.Open))
            {
                var xmlserilizer = new XmlSerializer(typeof(List<Person>));
                var loadedPeople= xmlserilizer.Deserialize(fs) as List<Person>;
                foreach (var item in loadedPeople)
                {
                    WriteLine($"{item.LastName}有{item.Children.Count}个孩子");
                }
            }


            string jsonFile = @"C:\code\people.json";
            using (FileStream fs = File.Create(jsonFile))
            {
                // create an object that will format as JSON
                var jss = new JavaScriptSerializer();
                var jsonStr= jss.Serialize(people);
                using (StreamWriter sw=new StreamWriter(fs))
                {
                    sw.Write(jsonStr);
                }
            }
            WriteLine($"{jsonFile}的文件大小是{new FileInfo(jsonFile).Length}字节");
            WriteLine($"{jsonFile}的内容是:{File.ReadAllText(jsonFile)}");

            string binaryFilepath = @"C:\Code\Ch10_People.bin";
            using (FileStream fs=File.Create(binaryFilepath))
            {
                var bf = new BinaryFormatter();
                bf.Serialize(fs, people);
            }
            using (var sr=File.OpenText(binaryFilepath))
            {
            }
            WriteLine($"{binaryFilepath}的文件大小是{new FileInfo(binaryFilepath).Length}字节");
            WriteLine(File.ReadAllText(binaryFilepath));
            Read();
        }
    }
}
