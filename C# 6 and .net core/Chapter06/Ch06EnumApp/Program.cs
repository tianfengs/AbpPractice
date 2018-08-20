using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using System.Threading.Tasks;

namespace Ch06EnumApp
{
    class Program
    {
        delegate int mydelegate(int i);
        static void Main(string[] args)
        {
            var p = new Person();

            WriteLine((int)FavouriteCar.QiYa);
            WriteLine((int)FavouriteCar.Bmw);
            WriteLine((int)FavouriteCar.Benz);
            WriteLine((int)FavouriteCar.FeryyLi);


            p.CarList = FavouriteCar.Benz | FavouriteCar.FeryyLi;
            // p.CarList = (FavouriteCar)16;
            WriteLine($"p.CarList={p.CarList}");
            WriteLine(p.Children[0].Name);
            WriteLine(p[1].Name);

            var d = new mydelegate(Mymultiply);
            var answer = d.Invoke(3);
            var answer2 = d(4);
            WriteLine($"{answer},{answer2}");

            //事件
            p.Shout += P_Shout;
            p.Poke();
            p.Poke();
            p.Poke();
            p.Poke(); p.Poke();
            Read();
        }

        private static void P_Shout(object sender, EventArgs e)
        {
            var p = (Person)sender;
            WriteLine($"{p.Name}的angerLevel是{p.AngerLevel}");
        }

        static int Mymultiply(int i)
        {
            return i * i;
        }
    }

    class Person
    {
        public string Name { get; set; }
        public FavouriteCar CarList { get; set; }
        public List<Person> Children => new List<Person> { new Person { Name = "小米" }
        ,new Person { Name = "小红" } };

        public Person this[int index]
        {
            get
            {
                return Children[index];
            }
            set
            {
                Children[index] = value;
            }
        }

        public event EventHandler Shout;
        public int AngerLevel = 0;
        public void Poke()
        {
            AngerLevel++;
            if (AngerLevel >= 3)
            {
                if (Shout != null)
                {
                    Shout(this, EventArgs.Empty);
                }
            }
        }
    }
}
