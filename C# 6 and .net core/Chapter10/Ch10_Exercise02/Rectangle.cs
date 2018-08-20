using System;
using System.Xml.Serialization;
namespace Ch10_Exercise02
{
    public class Rectangle : Shape
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public override double Area
        {
            get
            {
                return Height * Width;
            }
        }
    }
}