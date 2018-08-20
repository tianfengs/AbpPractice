using System.Xml.Serialization;
using System;
namespace Ch10_Exercise02
{
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public override double Area
        {
            get
            {
                return Math.PI * Radius * Radius;
            }
        }
     
    }
}