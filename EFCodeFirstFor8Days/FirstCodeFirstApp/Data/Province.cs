using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Province
    {
        public Province()
        {
            Donators=new HashSet<Donator>();
        }
        public int Id { get; set; }
        [StringLength(10)]
        public string Name { get; set; }

        public virtual ICollection<Donator> Donators { get; set; }
    }
}
