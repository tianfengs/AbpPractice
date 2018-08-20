using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using CryptorTools;

namespace Ch11_Signing
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("Enter some text to sign: ");
            string data = ReadLine();
            var signature = Protector.GenerateSignature(data);
            WriteLine($"Signature: {signature}");
            WriteLine("Public key used to check signature:");
            WriteLine(Protector.PublicKey);

            if (Protector.ValidateSignature(data, signature))
            {
                WriteLine("Correct! Signature is valid.");
            }
            else
            {
                WriteLine("Invalid signature.");
            }

            Read();
        }
    }
}
