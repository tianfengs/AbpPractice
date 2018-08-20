using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Ch14_AspNetCoreWebApp.Models
{
    public partial class Products
    {
        public Products()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int ProductId { get; set; }
        [Display(Name ="产品名称")]
        public string ProductName { get; set; }
        public int? SupplierId { get; set; }
        public int? CategoryId { get; set; }
        public string QuantityPerUnit { get; set; }
        [Display(Name ="单价")]
        public decimal? UnitPrice { get; set; }
        [Display(Name ="股票单价")]
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual Categories Category { get; set; }
        public virtual Suppliers Supplier { get; set; }
    }
}
