using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace BasicSharedModel
{
    public class Employee:Person
    {
        public string StaffNo { get; set; }

        public new void WriteToConsole()
        {
            WriteLine($"{Name}的出生日期是{DateOfBirth},工号是：{StaffNo}");
        }

        public override string ToString()
        {
            return $"{Name}的工号是{StaffNo}";
        }
        public sealed override void Work()
        {
            WriteLine("员工在工作！");
        }
    }
}
