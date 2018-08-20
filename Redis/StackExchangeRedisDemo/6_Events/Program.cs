using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using StackExchange.Redis;
using System.Threading;

namespace _6_Events
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigurationOptions option = new ConfigurationOptions
            {
                ConnectRetry = 5,
                EndPoints = { { "localhost", 6379 }, }
            };
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(option);
            var ran = new Random();
            
            redis.ConfigurationChanged += Redis_ConfigurationChanged;
            redis.ConnectionFailed += Redis_ConnectionFailed;
            
            while (true)
            {
                var number = ran.Next(1, 10);
                WriteLine($"当前随机值{number}");
                //每次产生3的倍数的值时，都会修改配置，然后触发ConfigurationChanged事件，输出“配置更改了”
                if (number % 3 == 0)
                {
                    option.ConnectRetry = number;
                    redis.Configure();
                    Thread.Sleep(2000);
                }
            }
            
        }

        private static void Redis_ConnectionFailed(object sender, ConnectionFailedEventArgs e)
        {
            WriteLine("连接失败了");
        }

        private static void Redis_ConfigurationChanged(object sender, EndPointEventArgs e)
        {
            WriteLine("配置更改了");
        }
    }
}
