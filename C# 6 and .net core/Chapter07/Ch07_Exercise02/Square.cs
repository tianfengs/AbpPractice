using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch07_Exercise02
{
    class Square:Shape
    {
        public override double Area
        {
            get
            {
                return Height*Height;
            }

            set
            {
                base.Area = value;
            }
        }
    }
}
