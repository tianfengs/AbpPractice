using System.Xml.Serialization;
namespace Ch10_Exercise02
{
    [XmlInclude(typeof(Circle))]
    [XmlInclude(typeof(Rectangle))]
    public abstract class Shape
    {
        public abstract  double Area { get; }
        public string Colour { get; set; }
    }
}