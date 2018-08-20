using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyAndTransactionManagement
{
    [Table("Donators")]
    public class Donator
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime DonateDate { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
