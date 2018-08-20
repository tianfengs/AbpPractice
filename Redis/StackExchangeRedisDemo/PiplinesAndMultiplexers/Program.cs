using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiplinesAndMultiplexers
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
            IDatabase db = redis.GetDatabase();

            #region Pipelining
            var aPending = db.StringGetAsync("a");
            var bPending = db.StringGetAsync("b");

            db.Wait(aPending);
            db.Wait(bPending);
            aPending.Wait();
            Task.WaitAll(aPending, bPending);
            #endregion

            #region Fire and Forget
            // sliding expiration
            var key = "a";
            db.KeyExpire(key, TimeSpan.FromMinutes(5), flags: CommandFlags.FireAndForget);
            var value = (string)db.StringGet(key);
            #endregion

            #region Multiplexing
            var sub = redis.GetSubscriber();
            var myChannel = "myChannel";
            sub.Subscribe(myChannel, (channel, message) =>
            {
                string work = db.ListRightPop(key);
                if (work != null) Process(work);
            });

            var newWork = string.Empty;
            db.ListLeftPush(key, newWork, flags:CommandFlags.FireAndForget);
            sub.PublishAsync(myChannel,string.Empty);
            #endregion
        }

        private static void Process(string work)
        {
            throw new NotImplementedException();
        }
    }
}
