using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace _4_KeysValuesChannels
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");

            IDatabase db = redis.GetDatabase();
            //RedisKey可以和string，byte[]类型互相隐式转换
            string keyStr = "9";
            byte[] keyByte =new byte[2] { 1,2};
            db.KeyDelete(keyStr);
            db.StringSet(keyStr, 23333);
            var number= db.StringIncrement(keyStr);
            WriteLine(keyStr);//23334
            db.StringIncrement(keyByte);
            WriteLine(keyByte);
            RedisKey redisKey = keyStr;

            RedisKey randomKey= db.KeyRandom();
            db.StringSet(randomKey,"randomValue");
            WriteLine(randomKey);


            //所有的值都是存储到RedisValue类型中的，从基本类型可以到RedisValue类型隐式转换
            RedisValue redisValue = db.StringGet(randomKey);
            db.StringSet("123key", "123");
            string value123 = db.StringGet("123key");
            WriteLine(value123);
            db.StringSet("123int", 123);
            //从RedisValue到基本类型是需要显式转换的
            int int123 = (int)db.StringGet("123int");
            WriteLine(int123);

            //当数字对待时，不存在的key默认值为0，为保持一致，nil响应也会认为是0
            db.KeyDelete("123key");
            int valueOfKeyNonExistent = (int)db.StringGet("123key");
            WriteLine(valueOfKeyNonExistent);//0

            //如果需要检测是否是Nil，可以这样做
            db.KeyDelete("123key");
            var valueOfNonExistent = db.StringGet("123key");
            bool isNil = valueOfNonExistent.IsNull;

            //也可以这样检测是否是nil
            var nullableValue = (int?)db.StringGet("123key");

            #region Lua 脚本
            var luaScript = "";
            //返回RedisResult类型
            var result = db.ScriptEvaluate(luaScript,new RedisKey[]{ },new RedisValue[] { });
            //还可以返回数组类型
            //string[] items = db.ScriptEvaluate(...);
            #endregion

            ReadLine();
        }
    }
}
