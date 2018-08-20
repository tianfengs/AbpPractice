using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostSharpLocationInterceptionDemo
{
    public class TestClass2
    {
        [MyLocationAspect]
        public string TestProperty
        {
            get;
            set;
        }
    }
}
