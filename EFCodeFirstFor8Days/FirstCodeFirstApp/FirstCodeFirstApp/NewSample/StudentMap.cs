using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstCodeFirstApp.NewSample
{
    public class StudentMap:EntityTypeConfiguration<Student>
    {
        public StudentMap()
        {
            HasRequired(s=>s.Person)
                .WithOptional(p=>p.Student);
            HasKey(s => s.PersonId);
            Property(s => s.CollegeName)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
