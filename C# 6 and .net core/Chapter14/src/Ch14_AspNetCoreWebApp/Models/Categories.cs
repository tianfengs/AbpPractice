using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Ch14_AspNetCoreWebApp.Models
{
    public partial class Categories
    {
        public Categories()
        {
            Products = new HashSet<Products>();
        }

        public int CategoryId { get; set; }
        [Display(Name ="种类")]
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
