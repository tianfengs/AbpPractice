using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ThreeInheritance
{
    //[Table("Vendors")]
    public class Vendor : Person
    {
        public decimal HourlyRate { get; set; }
    }
}
