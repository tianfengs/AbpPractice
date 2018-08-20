using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Patterns.Model;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Extensibility;
using PostSharp.Patterns.Threading;

namespace AopFirstDemo.PostSharpTutorials
{
    [Freezable, NotifyPropertyChanged]
    public class CustomerForEditing
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get { return string.Format("{0}{1}",FirstName,LastName); }
        }


        //[Log]
        public void Save(string firstName,string lastName)
        {
            Console.WriteLine("保存成功！");
        }
    }
}
