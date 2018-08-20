using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;
using System.IO.Compression;
using System.Xml;
namespace Ch10Streams
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write(sizeof(decimal));
            //WriteLine(decimal.MaxValue);
            // define an array of strings
            string[] callsigns = new string[] { "Husker", "Starbuck", "Apollo", "Boomer", "Bulldog", "Athena", "Helo", "Racetrack" };
            // define a file to write to using a text writer helper 
            string textFile = @"C:\Code\Ch10_Streams.txt";
            using (StreamWriter sw = File.CreateText(textFile))
            {
                foreach (var item in callsigns)
                {
                    sw.WriteLine(item);
                }
            }
            WriteLine($"{textFile}的文件大小是{new FileInfo(textFile).Length}字节");
            WriteLine(File.ReadAllText(textFile));

            // define a file to write to using the XML writer helper
            string xmlFile = @"C:\Code\Ch10_Streams.gzip";
            using (FileStream xmlfs = File.Create(xmlFile))
            {
                using (GZipStream gzipCompressor = new GZipStream(xmlfs, CompressionMode.Compress))
                {
                    using (XmlWriter xml = XmlWriter.Create(gzipCompressor))
                    {
                        //xml声明
                        xml.WriteStartDocument();
                        //xml根节点
                        xml.WriteStartElement("callsigns");
                        foreach (var item in callsigns)
                        {
                            xml.WriteElementString("callsign", item);
                        }
                        xml.WriteEndElement();
                    }
                }

            }
            WriteLine($"{xmlFile}的压缩文件大小是:{new FileInfo(xmlFile).Length}字节");
            WriteLine(File.ReadAllText(xmlFile));


            //读取解压缩文件
            WriteLine("正在读取压缩文件：");
            using (GZipStream decompressor = new GZipStream(File.OpenRead(xmlFile), CompressionMode.Decompress))
            {
                using (XmlReader reader=XmlReader.Create(decompressor))
                {
                    while (reader.Read())
                    {
                        //检查当前是否在一个叫做callsign的节点上
                        if (reader.NodeType==XmlNodeType.Element&&(reader.Name=="callsign"))
                        {
                            reader.Read();//指向下一个节点
                            WriteLine($"{reader.Value}");
                        }
                    }
                }
            }
            DeleteSpecifiedFile(textFile);
            Read();
        }

        static void DeleteSpecifiedFile(string filePath)
        {
            File.Delete(filePath);
            WriteLine($"文件{filePath}已删除");
        }
    }
}
