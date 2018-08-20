using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using ABPMVCTest.Authorization.Roles;
using ABPMVCTest.Entities;
using ABPMVCTest.MultiTenancy;
using ABPMVCTest.Users;

namespace ABPMVCTest.EntityFramework
{
    public class ABPMVCTestDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        //public virtual DbSet<Donator> Donators { get; set; }
        //public virtual DbSet<DonateWay> DonateWays { get; set; }
        public ABPMVCTestDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in ABPMVCTestDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of ABPMVCTestDbContext since ABP automatically handles it.
         */
        public ABPMVCTestDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public ABPMVCTestDbContext(DbConnection connection)
            : base(connection, true)
        {

        }
    }
}
