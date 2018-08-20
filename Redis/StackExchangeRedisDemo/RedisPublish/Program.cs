using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace RedisPublish
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
            ISubscriber subscriber = redis.GetSubscriber();

            subscriber.Publish("messages", "Hello,Sub/Pub");
            WriteLine("Messages have been published!");
            Read();
        }
    }
}
