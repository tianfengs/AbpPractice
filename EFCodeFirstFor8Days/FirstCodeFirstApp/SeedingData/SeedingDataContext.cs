using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedingData
{
    public class SeedingDataContext:DbContext
    {
        public virtual DbSet<Employer> Employers { get; set; }

        public SeedingDataContext()
            : base("name=SeedingData")
        {
            Database.SetInitializer(new SeedingDataInitializer());
        }
    }
}
