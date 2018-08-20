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
    [Table("Donators")]
    public class Donator:Entity
    {
        [StringLength(10)]
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime DonateDate { get; set; }
        [StringLength(50)]
        public string Message { get; set; }

        public virtual ICollection<DonateWay> DonateWays { get; set; }
    }
}
