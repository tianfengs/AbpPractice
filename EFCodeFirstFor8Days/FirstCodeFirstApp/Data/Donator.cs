using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Donator
    {
        public int Id { get; set; }
        [StringLength(10)]
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime DonateDate { get; set; }
        public int ProvinceId { get; set; }
        public virtual Province  Province{ get; set; }
        [StringLength(50)]
        public string Message { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
