using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostSharpUT
{
    public static class Log
    {
        private static List<string> _messages=new List<string>();

        public static List<string> Messages
        {
            get { return _messages; }
        }

        public static void Write(string message)
        {
            _messages.Add(message);
        }
    }
}
