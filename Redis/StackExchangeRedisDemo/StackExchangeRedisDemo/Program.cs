using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace StackExchangeRedisDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var connString = "localhost";
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(connString);
            //ConnectionMultiplexer redis2 = ConnectionMultiplexer.Connect(new ConfigurationOptions
            //{
            //    ConnectRetry=3
            //});
            //连接字符串支持逗号分隔的节点
            //ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("server1:6379,server2:6379");

            #region Using a redis database
            IDatabase db = redis.GetDatabase();

            //int dbNumber = 1;
            //object asyncState = ""; 
            //IDatabase db2 = redis.GetDatabase(dbNumber,asyncState);
            //foreach (var item in Enumerable.Range(1, 50))
            //{
            //    db.StringSet("mykey" + item, "farb" + item);
            //    string value = db.StringGet("mykey" + item);
            //    WriteLine(value);
            //}

            #endregion


            #region Using redis pub/sub
            ISubscriber subscriber = redis.GetSubscriber();
            subscriber.Subscribe("messages", (channel, message) =>
            {
                WriteLine(message);
            });
            #endregion

            #region Accessing individual servers
            IServer server = redis.GetServer(connString,6379);
            EndPoint[] endPoints= redis.GetEndPoints();

            DateTime dateTime= server.LastSave();
            WriteLine(dateTime);
            ClientInfo[] clientInfo= server.ClientList();
            
            #endregion
            redis.Dispose();
            ReadKey();
        }
    }
}
