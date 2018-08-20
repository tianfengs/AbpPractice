using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace Ch11_Exercise02
{
    class Program
    {
        private static readonly string password = "hello";
        static void Main(string[] args)
        {
            var me = new Person
            {
                Name = "farb",
                CreditCard = "1234-5678-9",
                Password = "pa$$w0rd"
            };
            //1.序列化成xml文件
            string accountXml = "account.xml";
            var xmlSer = new XmlSerializer(typeof(Person));
            using (var fs=File.Create(accountXml))
            {
                xmlSer.Serialize(fs, me);
            }
            WriteLine($"序列化的明文是：");
            WriteLine(File.ReadAllText(accountXml));
            //2.序列化为加密的xml文件

            string encryptedXml = "encryptedAccount.xml";
            me.CreditCard = CryptorTool.Encrypt(me.CreditCard, password);//对信用卡号加密
            me.Password = CryptorTool.GetSaltedHashedPwd(me.Password);//密码加盐并哈希

            using (TextWriter tw= File.CreateText(encryptedXml))
            {
                xmlSer.Serialize(tw, me);
            }

            WriteLine($"加密后的xml是：");
            WriteLine(File.ReadAllText(encryptedXml));

            //3.解密上面的信用卡号
            using (StreamReader sr=File.OpenText(encryptedXml))
            {
                var p= xmlSer.Deserialize(sr) as Person;
                p.CreditCard = CryptorTool.Decrypt(p.CreditCard,password);
                WriteLine($"用户的信用卡号是:{p.CreditCard}");
            }
            Read();
        }


    }
}
