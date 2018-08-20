using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ch08_EFCore
{
    [Table("Products")]
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }
    }
}
