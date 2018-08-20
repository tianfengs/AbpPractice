using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ch14_AspNetCoreWebApp.Models
{
    public class HomeIndexViewModel
    {
        public int VisitorCount { get; set; }
        public ICollection<Products> Products { get; set; }
    }
}
