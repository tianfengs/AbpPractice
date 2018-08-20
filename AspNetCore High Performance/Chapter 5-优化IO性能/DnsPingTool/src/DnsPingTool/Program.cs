using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace DnsPingTool
{
    public class Program
    {
        public static void Main(string[] args)
        {
            OutputEncoding = Encoding.GetEncoding("utf-8");
            WriteLine("Enter a hostname or IP address:");
            string hostname = @"www.farb.cnblogs.com";
            WriteLine($"hostname={hostname}");
            PingHost(hostname).Wait();
            DnsLookup(hostname).Wait();
            WriteLine("Press any key to exit...");
            Read();
        }
        public static async Task DnsLookup(string host)
        {
            try
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine($"Performing DNS lookup of {host}");
                IPAddress[] ipArr=await Dns.GetHostAddressesAsync(host);
                //
                foreach (IPAddress ip in ipArr)
                {
                    ForegroundColor = ConsoleColor.Magenta;
                    WriteLine($"Complete,{host}={ip}");
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine($"Performing reverse DNS lookup of {ip}");
                    IPHostEntry entry= await Dns.GetHostEntryAsync(ip);
                    ForegroundColor = ConsoleColor.Magenta;
                    WriteLine($"Complete,{ip}={entry.HostName}");
                    WriteLine();
                }
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
        }
        public static async Task PingHost(string host)
        {
            var tempts = 4;
            ForegroundColor = ConsoleColor.Gray;
            WriteLine($"Ping {host} {tempts} times !");
            var ping = new Ping();
            for (int i = 0; i < tempts; i++)
            {
                ForegroundColor = ConsoleColor.DarkGreen;
                WriteLine($"Ping attemp {i+1}of {tempts}...");
               var result=await ping.SendPingAsync(host);
                ForegroundColor = ConsoleColor.Green;
                WriteLine($"Ping Status:{result.Status},RoundtripTime:{result.RoundtripTime}ms");
            }
            WriteLine();
        }
    }
}
