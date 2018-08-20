using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch13_DataBinding.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime DoB { get; set; }

        public decimal Salary { get; set; }
    }
}
