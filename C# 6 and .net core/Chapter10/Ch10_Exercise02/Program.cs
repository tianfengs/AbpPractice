using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Xml.Serialization;
using System.IO;
namespace Ch10_Exercise02
{
    class Program
    {
        static void Main(string[] args)
        {
            // create a list of Shapes to serialize
            var listOfShapes = new List<Shape>
            {
                new Circle { Colour = "Red", Radius = 2.5 },
                new Rectangle { Colour = "Blue", Height = 20.0, Width = 10.0 },
                new Circle { Colour = "Green", Radius = 8 },
                new Circle { Colour = "Purple", Radius = 12.3 },
                new Rectangle { Colour = "Blue", Height = 45.0, Width = 18.0  }
            };
            string xmlFile = @"shape.xml";
            var xmlSerializer = new XmlSerializer(typeof(List<Shape>));
            using (var fs=File.Create(xmlFile))
            {
                xmlSerializer.Serialize(fs, listOfShapes);
            }
            WriteLine($"{xmlFile}的文件大小：{new FileInfo(xmlFile).Length}字节");
            WriteLine(File.ReadAllText(xmlFile));

            using (var fs = File.OpenRead(xmlFile))
            {
                List<Shape> loadedShapes = xmlSerializer.Deserialize(fs) as List<Shape>;
                foreach (var item in loadedShapes)
                {
                    WriteLine($"{item.GetType().Name}的颜色是{item.Colour},面积是{item.Area}");
                }
            }

            Read();
        }
    }
}
