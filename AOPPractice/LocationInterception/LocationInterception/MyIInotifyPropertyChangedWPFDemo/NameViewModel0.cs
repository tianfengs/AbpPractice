using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyIInotifyPropertyChangedWPFDemo
{
    public class NameViewModel0:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged!=null)
            {
                PropertyChanged(this,new PropertyChangedEventArgs(propertyName));
            }
        }

        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (value!=_firstName)
                {
                    _firstName = value;
                    OnPropertyChanged("FirstName");
                    OnPropertyChanged("FullName");
                }
            }
        }

        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (value!=_lastName)
                {
                    _lastName = value;
                    OnPropertyChanged("LastName");
                    OnPropertyChanged("FullName");
                }
            }
        }

        public string FullName
        {
            get { return string.Format("{0}{1}", FirstName, LastName); }
        }

       
    }
}
