using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using StackExchange.Redis;
namespace _7_ServerCmd
{
    class Program
    {
        static void Main(string[] args)
        {
            var redis = ConnectionMultiplexer.Connect("localhost,allowAdmin=true");
            
            //需要理清一个关系：一台Redis server上可以有多个数据库，一个数据库也可以分部到多个Redis Server上。
            // 最简单的场景就是只有一台Redis Server,先从一个服务器看起

            
            var db = redis.GetDatabase();
            foreach (var i in Enumerable.Range(1,100))
            {
                if (i <= 30)
                {
                    var key = string.Concat("aaa-key-", i);
                    var value = string.Concat("aaa-value-", i);
                    if (!db.KeyExists(key)) db.StringSet(key,value);
                }
                else if(i<=60)
                {
                    var key = string.Concat("bbb-key-", i);
                    var value = string.Concat("bbb-value-", i);
                    if (!db.KeyExists(key)) db.StringSet(key, value);
                }
                else if (i <= 90)
                {
                    var key = string.Concat("ccc-key-", i);
                    var value = string.Concat("ccc-value-", i);
                    if (!db.KeyExists(key)) db.StringSet(key, value);
                }
                else
                {
                        var key = string.Concat("ddd-key-", i);
                        var value = string.Concat("ddd-value-", i);
                        if (!db.KeyExists(key)) db.StringSet(key, value);
                }

            }


            //获取某个服务器，这里是本机
            var server = redis.GetServer("localhost:6379");

            //打印database=0所有的key
            foreach (var item in server.Keys())
            {
                WriteLine(item);
            }
            //擦除所有database=0的key,擦除数据需要allowAdmin=true,也就是需要管理员权限
            server.FlushDatabase();

            var endpoints=redis.GetEndPoints();//获取该服务器上的所有终端
            ReadKey();
        }
    }
}
