using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
   public  class Context:DbContext
    {
       public Context()
           : base("name=DatabaseMigrationAppConn")
       {
           
       }

       public virtual DbSet<Donator> Donators { get; set; }
       public virtual DbSet<Province> Provinces { get; set; }

       protected override void OnModelCreating(DbModelBuilder modelBuilder)
       {
           //modelBuilder.Properties<string>().Configure(config=>config.IsUnicode(false));
           modelBuilder.Conventions.Add<CustomConventions>();
       }
    }
}
