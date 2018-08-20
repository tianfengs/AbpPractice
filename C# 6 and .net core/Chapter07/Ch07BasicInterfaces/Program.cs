using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Ch07BasicInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Person[] people ={
                new Person {Name="小芳" },
                new Person {Name="小李" },
                new Person { Name="小明"},
                new Person { Name="大兄弟"},
                new Person { Name="老王"},
                new Person { Name="小个子"},
            };
            Array.Sort(people,new PersonComparer());
            foreach (var item in people)
            {
                WriteLine(item.Name);
            }
            Read();
        }
    }
}
