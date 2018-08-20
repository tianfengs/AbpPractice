using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyIInotifyPropertyChangedWPFDemo
{
    public class NameViewModel2:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

      

        void OnPropertyChanged([CallerMemberName]string propertyName="")
        {
            if (PropertyChanged!=null)
            {
                PropertyChanged(this,new PropertyChangedEventArgs(propertyName));
            }
        }

        string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set {
                if (value!=_firstName)
                {
                    _firstName = value;
                    OnPropertyChanged();//这里就可以移除“FirstName”了
                    OnPropertyChanged("FullName");
                }
            }
        }
        string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (value != _firstName)
                {
                    _lastName = value;
                    OnPropertyChanged();//这里就可以移除“LastName”了
                    OnPropertyChanged("FullName");
                }
            }
        }
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", _firstName, _lastName);
            }
        }
    }
}