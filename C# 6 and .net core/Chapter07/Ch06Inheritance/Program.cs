using BasicSharedModel;
using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch06Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            var em = new Employee { Name = "王大锤", DateOfBirth = DateTime.Now.AddYears(-10), StaffNo = "1010" };
            em.WriteToConsole();
            WriteLine(em.ToString());
            //em.Work();
            Person emP = em;
            if (emP is Employee)
            {
                WriteLine($"{nameof(emP)} is Employee type！");
            }
            WriteLine(em.ToString());
            emP.WriteToConsole();
            Read();
        }
    }
}
