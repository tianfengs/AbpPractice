using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch07BasicInterfaces
{
    class Person:IComparable<Person>
    {
        public string Name { get; set; }


        public int CompareTo(Person other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}
