using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Text;
using System.Threading.Tasks;
using Ch09_MyLINQExtensions;
namespace Ch09_LinqToObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = new string[] { "Michael", "Pam", "Jim", "Dwight", "Angela", "Kevin", "Toby", "Creed" };
            //var query = names.Where(new Func<string, bool>(NameLongerThanFour));
            //var query = names.Where(NameLongerThanFour);
            var query = names
                .Where(n => n.Length > 4)
                .OrderBy(n=>n.Length)
                .ThenBy(n=>n);
            WriteLine(query.ToList().GetSequenceCount());
            foreach (var name in query)
            {
                WriteLine(name);
            }

            Read();
        }

        static bool NameLongerThanFour(string name)
        {
            return name.Length > 4;
        }
    }
}
