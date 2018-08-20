using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewsAndStoreProcedure
{
    public class DonatorViewInfo
    {
        public int DonatorId { get; set; }
        public string DonatorName { get; set; }
        public decimal Amount { get; set; }
        public DateTime DonateDate { get; set; }
        [StringLength(225)]
        public string ProvinceName { get; set; }
    }
}
