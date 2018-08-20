using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace DynamicProxyPractice
{
    public interface ISinaService
    {
        void SendMsg(string msg);
    }

    public class MySinaService:ISinaService
    {
        public void SendMsg(string msg)
        {
            WriteLine($"[{msg}] has been sent!");
        }
    }

    public class MySinaServiceProxy : ISinaService
    {
        private MySinaService _service;
        public MySinaServiceProxy()
        {
            _service = new MySinaService();
        }
        public void SendMsg(string msg)
        {
            WriteLine("Before");
            _service.SendMsg(msg);
            WriteLine("After");
        }
    }
}
