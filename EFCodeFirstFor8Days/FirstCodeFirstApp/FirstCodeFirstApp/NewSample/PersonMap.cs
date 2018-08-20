using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstCodeFirstApp.NewSample
{
    public class PersonMap:EntityTypeConfiguration<Person>
    {
        public PersonMap()
        {
            HasMany(p => p.Companies)
                .WithMany(c => c.Persons)
                .Map(m =>
                {
                    m.MapLeftKey("PersonId");
                    m.MapRightKey("CompanyId");
                    m.ToTable("PersonCompany");
                });
        }
    }
}
