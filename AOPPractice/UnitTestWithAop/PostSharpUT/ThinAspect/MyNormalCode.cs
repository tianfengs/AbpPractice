using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostSharpUT.ThinAspect
{
    public class MyNormalCode
    {
        [MyThinAspect]
        public string Reverse(string content)
        {
            return new string(content.Reverse().ToArray());
        }
    }
}
