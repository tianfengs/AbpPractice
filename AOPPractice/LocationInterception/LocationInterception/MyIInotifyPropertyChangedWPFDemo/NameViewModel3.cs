using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;

namespace MyIInotifyPropertyChangedWPFDemo
{
    [ImplementPropertyChanged]
    public class NameViewModel3
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return String.Format("{0}{1}", FirstName, LastName);
            }
        }
    }
}
