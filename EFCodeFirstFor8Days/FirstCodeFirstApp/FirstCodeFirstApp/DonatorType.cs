using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace FirstCodeFirstApp
{
    public class DonatorType
    {
        public int Id { set; get; }
        public string Name { set; get; }

        public virtual ICollection<Donator> Donators { get; set; }
    }
}
