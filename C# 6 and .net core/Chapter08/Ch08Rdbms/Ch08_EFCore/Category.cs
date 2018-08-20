using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ch08_EFCore
{
    [Table("Categories")]
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public Category()
        {
            Products = new HashSet<Product>();
        }
    }
}
