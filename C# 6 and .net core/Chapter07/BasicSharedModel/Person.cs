using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicSharedModel
{
    public class Person
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        public void WriteToConsole()
        {
            WriteLine($"{Name}的生日是{DateOfBirth}");
        }

        public override string ToString()
        {
            return $"{Name}的基类是{base.ToString()}";
        }

        public virtual void Work()
        {
            WriteLine($"People are working!");
        }
    }
}
