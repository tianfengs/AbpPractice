using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedingData
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var db = new SeedingDataContext())
            {

                var employers = db.Employers;
                foreach (var employer in employers)
                {
                    Console.WriteLine("Id={0}\tName={1}",employer.Id,employer.EmployerName);
                }
            }
            Console.WriteLine("DB创建成功，并完成种子化！");
            Console.Read();

        }
    }
}
