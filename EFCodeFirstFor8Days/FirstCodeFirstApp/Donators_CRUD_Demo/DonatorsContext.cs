using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donators_CRUD_Demo
{
    public class DonatorsContext : DbContext
    {
        public DonatorsContext()
            : base("name=DonatorsConn")
            {
            }

        public virtual DbSet<Donator> Donators { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        
    }
}
