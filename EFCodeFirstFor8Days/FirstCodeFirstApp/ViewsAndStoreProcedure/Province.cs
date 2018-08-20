using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewsAndStoreProcedure
{
    public class Province
    {
        public Province()
        {
            Donators = new HashSet<Donator>();
        }
        public int Id { get; set; }

        [StringLength(225)]
        public string ProvinceName { get; set; }

        public virtual ICollection<Donator> Donators { get; set; }
    }
}
