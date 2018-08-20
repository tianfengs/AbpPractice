using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Configuration
{
    class Program
    {
        static void Main(string[] args)
        {
            //最简单的配置只需要一个主机名就够了,会使用该主机的默认redis端口6379，额外的配置需要逗号分隔开，依次追加即可
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");

            //端口号用通常的冒号表示，配置选项使用=将键值对分隔开
            ConnectionMultiplexer redis2 = ConnectionMultiplexer.Connect("redis0:6380,redis1:6380,allowAdmin=true");

            string connectionString = "";
            //configurationOptions和connectionString 之间可以简单地转换
            ConfigurationOptions configurationOptions = ConfigurationOptions.Parse(connectionString);
            connectionString = configurationOptions.ToString();

            //常见用法是这样的：将基本的细节存储到字符串中，然后在运行时使用具体指定的配置细节
            string connString = GetRedisConfiguration();
            ConfigurationOptions options = ConfigurationOptions.Parse(connString);
            options.ClientName = GetAppName();//运行时才知道
            options.AllowAdmin = true;
            var conn = ConnectionMultiplexer.Connect(options);

            //Microsoft Azure Redis 样例
            var azureConn = ConnectionMultiplexer.Connect("contoso5.redis.cache.windows.net,ssl=true,password=...");


            var config = new ConfigurationOptions
            {
                EndPoints =
                {
                    {"redis0",6379},
                    {"redis1",6380}
                },
                CommandMap = CommandMap.Create(new HashSet<string>
                {
                    //排除一些命令
                    "INFO", "CONFIG", "CLUSTER",
                    "PING", "ECHO", "CLIENT"
                }, available: false),
                KeepAlive = 180,
                DefaultVersion = new Version(2, 8, 8),
                Password = "password"
            };
            //上面的config和下面的配置字符串是等价的
            string configString = "redis0:6379,redis1:6380,keepAlive=180,version=2.8.8,$CLIENT=,$CLUSTER=,$CONFIG=,$ECHO=,$INFO=,$PING=";

            var commands = new Dictionary<string, string>
            {
                {"info",null },//禁用info命令
                {"select","use" },//use代替select命令
            };

            var option = new ConfigurationOptions
            {
                CommandMap = CommandMap.Create(commands),
            };

            //option等价于$INFO=,$SELECT=use

            #region Twemproxy || Tiebreakers and Configuration Change Announcements


            //Twemproxy：https://github.com/twitter/twemproxy
            //Tiebreakers and Configuration Change Announcements

            var option2 = new ConfigurationOptions
            {
                Proxy = Proxy.Twemproxy,
                EndPoints = { "server" },
                TieBreaker= "__Booksleeve_TieBreak",//默认值
                ConfigurationChannel= "__Booksleeve_MasterChanged"//默认值
            };
            #endregion

            #region ReconnectRetryPolicy

            var option3 = new ConfigurationOptions
            {
                ConnectRetry=6,
                ReconnectRetryPolicy=new ExponentialRetry(5000),// defaults maxDeltaBackoff to 10000 ms
                //retry#    retry to re-connect after time in milliseconds
                //1	        a random value between 5000 and 5500	   
                //2	        a random value between 5000 and 6050	   
                //3	        a random value between 5000 and 6655	   
                //4	        a random value between 5000 and 8053
                //5	        a random value between 5000 and 10000, since maxDeltaBackoff was 10000 ms
                //6	        a random value between 5000 and 10000

                //config.ReconnectRetryPolicy = new LinearRetry(5000);
                //retry#    retry to re-connect after time in milliseconds
                //1	        5000
                //2	        5000 	   
                //3	        5000 	   
                //4	        5000
                //5	        5000
                //6	        5000
        };
            #endregion
        }

        private static string GetAppName()
        {
            throw new NotImplementedException();
        }

        private static string GetRedisConfiguration()
        {
            throw new NotImplementedException();
        }
    }
}
