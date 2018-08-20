using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstCodeFirstApp
{
   public class DonatorTypeMap:EntityTypeConfiguration<DonatorType>
   {
       public DonatorTypeMap()
       {
           HasMany(dt=>dt.Donators)
               .WithOptional(d=>d.DonatorType)
               .HasForeignKey(d=>d.DonatorTypeId)
               .WillCascadeOnDelete(false);
       }
   }
}
