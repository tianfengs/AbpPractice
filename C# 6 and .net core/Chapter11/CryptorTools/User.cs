using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptorTools
{
    public class User
    {
        public string Name { get; set; }
        public string Salt { get; set; }
        public string SaltedHashedPassword { get; set; }
    }
}
