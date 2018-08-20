using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInheritance
{
    public class Context:DbContext
    {
        public Context():base("ThreeInheritance")
        {
            
        }

        //public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Employees");
            });

            modelBuilder.Entity<Vendor>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Vendors");
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
