using CryptorTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace Ch11_Cryptography
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("Enter a message that you want to encrypt: ");
            string message = ReadLine();
            Write("Enter a password: ");
            string password = ReadLine();
            string cryptoText = Protector.Encrypt(message, password);
            WriteLine($"Encrypted text: {cryptoText}");
            string clearText = Protector.Decrypt(cryptoText, password);
            WriteLine($"Decrypted text: {clearText}");

            Read();
        }
    }
}
