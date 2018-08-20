using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.Entities
{
    /// <summary>
    /// 发票实体
    /// </summary>
    public class Invoice
    {
        public Guid Id { get; set; }
        public Customer Customer { get; set; }
        public Vehicle Vehicle { get; set; }
        public decimal CostPerDay { get; set; }
        public decimal Discount { get; set; }
    }
}
