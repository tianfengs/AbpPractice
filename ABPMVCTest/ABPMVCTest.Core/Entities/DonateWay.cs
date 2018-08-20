using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;

namespace ABPMVCTest.Entities
{
    [Table("DonateWays")]
    public class DonateWay:Entity
    {
        [StringLength(5)]
        public string Name { get; set; }

        public virtual ICollection<Donator> Donators { get; set; }
    }
}
