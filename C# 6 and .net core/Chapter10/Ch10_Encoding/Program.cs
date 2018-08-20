using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;
using static System.Console;
namespace Ch10_Encoding
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Encodings");
            WriteLine("[1] ASCII");
            WriteLine("[2] UTF-7");
            WriteLine("[3] UTF-8");
            WriteLine("[4] UTF-16 (Unicode)");
            WriteLine("[5] UTF-32");
            WriteLine("[any other key] Default");

            // choose an encoding
            Write("Press a number to choose an encoding: ");
            ConsoleKey number= ReadKey(false).Key;
            WriteLine();
            WriteLine();
            Encoding encoder;
            switch (number)
            {
                case ConsoleKey.D1:
                    encoder = Encoding.ASCII;
                    break;
                case ConsoleKey.D2:
                    encoder = Encoding.UTF7;
                    break;
                case ConsoleKey.D3:
                    encoder = Encoding.UTF8;
                    break;
                case ConsoleKey.D4:
                    encoder = Encoding.Unicode;
                    break;
                case ConsoleKey.D5:
                    encoder = Encoding.UTF32;
                    break;
                default:
                    encoder = Encoding.Default;
                    break;
            }

            // define a string to encode
            string message = "A bottle of milk is £1.99";
            // encode the string into a byte array
            byte[] encoded = encoder.GetBytes(message);
            // check how many bytes the encoding needed
            WriteLine($"{encoder.GetType().Name}需要使用{encoded.Length}字节");
            // enumerate each byte
            WriteLine($"Byte  Hex  Char");
            foreach (byte b in encoded)
            {
                WriteLine($"{b,4} {b.ToString("X")} {(char)b,5}");
            }
            // decode the byte array back into a string and display it
            var decodeStr = encoder.GetString(encoded);
            WriteLine(decodeStr);
            Read();
        }
    }
}
