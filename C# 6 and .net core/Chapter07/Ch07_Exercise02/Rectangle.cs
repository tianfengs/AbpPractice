using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch07_Exercise02
{
    class Rectangle:Shape
    {
        public override double Area
        {
            get
            {
                return Height*Width;
            }

            set
            {
                base.Area = value;
            }
        }
    }
}
