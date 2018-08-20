using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostSharpLocationInterceptionDemo
{
    public class TestClass
    {
        public string TestProperty
        {
            get;
            [MyMethodAspect]
            set;
        }
    }
}
