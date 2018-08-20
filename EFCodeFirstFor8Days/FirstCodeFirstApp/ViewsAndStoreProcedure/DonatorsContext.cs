using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewsAndStoreProcedure.ConfigMap;

namespace ViewsAndStoreProcedure
{
    public class DonatorsContext : DbContext
    {
        public DonatorsContext()
            : base("name=DonatorsConn")
            {
            }
        public  DbSet<Province> Provinces { get; set; }
        public  DbSet<Donator> Donators { get; set; }
        public  DbSet<DonatorViewInfo> DonatorViews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProvinveMap());
            modelBuilder.Configurations.Add(new DonatorMap());
            modelBuilder.Configurations.Add(new DonatorViewInfoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
