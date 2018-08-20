using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace _5_Transactions_In_Redis
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionMultiplexer redisServer = ConnectionMultiplexer.Connect("localhost");
            IDatabase db = redisServer.GetDatabase();
            /*
             eg. 在更新一个实体的Id时，先去检查这个Id是否存在,
                如果不存在再更新，否则不更新
             */
            var key = "mykey";
            var newId = CreateNewId();
            var trans=db.CreateTransaction();
            //Condition类是不可扩展的
            trans.AddCondition(Condition.HashNotExists(key, "UniqueID"));
            //事务只能调用异步方法，因为每一个操作只有当Execute方法执行完毕之后才知道结果
            trans.HashSetAsync(key, "UniqueID", newId);
            //可以使用When.NotExists代替上面的条件语句
            //trans.HashSetAsync(key, "UniqueID", newId, When.NotExists);
            // ^^^ if true: it was applied; if false: it was rolled back
            bool committed = trans.Execute();

            #region Lua
            /*
             * EVAL "if redis.call('hexists', KEYS[1], 'UniqueId') 
                then return redis.call('hset', KEYS[1], 'UniqueId', ARGV[1]) 
                else return 0 end" 1 {custKey} {newId}
            */
            //其实就像EF直接调用sql语句一样

            //返回类型可以根据具体脚本执行的返回值进行强制转换，这里转成了bool
            var wasSet = (bool)db.ScriptEvaluate(@"if redis.call('hexists', KEYS[1], 'UniqueId') then return redis.call('hset', KEYS[1], 'UniqueId', ARGV[1]) else return 0 end",
                new RedisKey[] { key }, new RedisValue[] { newId });


            #endregion
            ReadLine();
        }

        private static string CreateNewId()
        {
            return "123";
        }
    }
}
