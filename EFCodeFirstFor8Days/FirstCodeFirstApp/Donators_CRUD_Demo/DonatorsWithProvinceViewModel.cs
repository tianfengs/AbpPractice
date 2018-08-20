using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donators_CRUD_Demo
{
    public class DonatorsWithProvinceViewModel
    {
        public string Province { get; set; }
        public ICollection<Donator> DonatorList { get; set; }
    }
}
