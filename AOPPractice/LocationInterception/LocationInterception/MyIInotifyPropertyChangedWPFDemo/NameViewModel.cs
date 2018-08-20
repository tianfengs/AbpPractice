using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyIInotifyPropertyChangedWPFDemo
{
    public class NameViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
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
