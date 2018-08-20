using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransactionCastle
{
   public  class Invoice
    {
       public Guid Id { get; set; }
       public DateTime Date { get; set; }
       public List<string> Items { get; set; }
    }
}
