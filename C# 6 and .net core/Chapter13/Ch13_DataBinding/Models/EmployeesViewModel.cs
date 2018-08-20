using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch13_DataBinding.Models
{
    public class EmployeesViewModel
    {
        public EmployeesViewModel()
        {
            Employees = new HashSet<Employee>();
            Employees.Add(new Employee { Id = 1, Name = "Alice", DoB = new DateTime(1992, 1, 27), Salary = 34000M });
            Employees.Add(new Employee { Id = 2, Name = "Bob",  DoB = new DateTime(1995, 4, 13), Salary = 64000M });
        }
        public HashSet<Employee> Employees { get; set; }

    }
}
