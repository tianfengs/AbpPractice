using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.DataProtection;
using static System.Console;
namespace DataProtectionApp
{

    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDataProtection();

            var services = serviceCollection.BuildServiceProvider();

            var protector = services.GetDataProtector("DataProtectionSample");

            WriteLine("Sample is following:");
            string protectedData = protector.Protect("Hello world!");
            WriteLine($"protectedData is {protectedData}");
            string unprotectedData = protector.Unprotect(protectedData);
            WriteLine($"unprotectedData is {unprotectedData}");

            while (true)
            {
                WriteLine("Please input your plain text:");
                string plainText = ReadLine();
                string protectPayload= protector.Protect(plainText);
                WriteLine($"protectPayload is {protectPayload}");
                string unprotectPayload = protector.Unprotect(protectPayload);
                WriteLine($"unprotectPayload is {unprotectPayload}");
            }
        }
    }
}