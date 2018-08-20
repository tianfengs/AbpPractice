using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedingData
{
    public class SeedingDataInitializer:DropCreateDatabaseAlways<SeedingDataContext>
    {
        protected override void Seed(SeedingDataContext context)
        {
            for (int i = 0; i < 6; i++)
            {
                var employer = new Employer { EmployerName = "Employer"+(i+1) };
                context.Employers.Add(employer);
            }
            base.Seed(context);
        }
    }
}
