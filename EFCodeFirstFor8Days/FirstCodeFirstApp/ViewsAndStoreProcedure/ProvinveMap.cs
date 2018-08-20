using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewsAndStoreProcedure
{
    public class ProvinveMap:EntityTypeConfiguration<Province>
    {
        public ProvinveMap()
        {
            HasMany(p => p.Donators)
                .WithRequired()
                .HasForeignKey(d => d.ProvinceId);
        }
    }
}
