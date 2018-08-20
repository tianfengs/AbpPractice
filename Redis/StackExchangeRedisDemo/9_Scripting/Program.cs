using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using StackExchange.Redis;
namespace _9_Scripting
{
    class Program
    {
        static void Main(string[] args)
        {
            //类似于sql的参数化查询
            const string Script = "redis.call('set', @key, @value)";

            using (var redis=ConnectionMultiplexer.Connect("localhost"))
            {
                var db = redis.GetDatabase();
                var prepared = LuaScript.Prepare(Script);
                db.ScriptEvaluate(prepared,new { key="mykey",value=123});
            }


            //为了避免每次执行脚本的时候都将Lua脚本传输到Redis服务器，可以通过LuaScript.Load(IServer)将LuaScript转换成LoadedLuaScripts,它是通过EvalSha计算的 。

            using (var redis = ConnectionMultiplexer.Connect("localhost"))
            {
                var db = redis.GetDatabase();
                var server = redis.GetServer("localhost:6379");
                var prepared = LuaScript.Prepare(Script);
                var loaded = prepared.Load(server);
                db.ScriptEvaluate(prepared, new { key = "mykey", value = 123 });
            }
            WriteLine("Ok");
            Read();
        }

    
    }
}
