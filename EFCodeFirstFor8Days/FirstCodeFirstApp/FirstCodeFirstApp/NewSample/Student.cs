using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstCodeFirstApp.NewSample
{
    public class Student
    {
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
        public string CollegeName { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}
