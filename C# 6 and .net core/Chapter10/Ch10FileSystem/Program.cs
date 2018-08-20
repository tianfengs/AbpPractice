using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;
namespace Ch10FileSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string dirStr = @"C:\Net Core";
            //检查是否存在目录
            WriteLine($"{dirStr}存在吗？{Directory.Exists(dirStr)}");

            //创建目录
            Directory.CreateDirectory(dirStr);
            Read();
            //检查是否存在目录
            WriteLine($"{dirStr}存在吗？{Directory.Exists(dirStr)}");
            //删除目录
            Directory.Delete(dirStr,true);
            //检查是否存在目录
            WriteLine($"{dirStr}存在吗？{Directory.Exists(dirStr)}");
            Directory.CreateDirectory(dirStr);
            //检查文件是否存在
            string file = dirStr + "\\test.txt";
            WriteLine($"{file}存在吗？{File.Exists(file)}");
            //创建一个文本文件
            StreamWriter sw = File.CreateText(file);
            WriteLine($"{file}存在吗？{File.Exists(file)}");
            //写入文本
            sw.WriteLine("Hello,C# IO ");
            sw.Dispose();

            //创建一个备份
            File.Copy(file, file + ".bak",true);
            Read();
            //删除原始文件
            File.Delete(file);
            WriteLine($"{file}存在吗？{File.Exists(file)}");

            //读取备份文件的内容
            StreamReader sr= File.OpenText(file + ".bak");
            string content = sr.ReadToEnd();
            WriteLine($"文本内容是{content}");

            sr.Dispose();
            //管理路径
            var existingFile = file + ".bak";
            WriteLine($"文件名是：{Path.GetFileName(existingFile)}");
            WriteLine($"没有扩展名的文件名：{Path.GetFileNameWithoutExtension(existingFile)}");
            WriteLine($"文件的扩展名是:{Path.GetExtension(existingFile)}");
            WriteLine($"随机文件名：{Path.GetRandomFileName()}");
            WriteLine($"临时文件名：{Path.GetTempFileName()}");

            //获取更多信息
            var fileInfo = new FileInfo(existingFile);
            WriteLine($"文件的大小：{fileInfo.Length}");
            WriteLine($"文件的最后访问时间:{fileInfo.LastAccessTime}");
            WriteLine($"文件的只读属性:{fileInfo.IsReadOnly}");

            Read();
        }
    }
}
