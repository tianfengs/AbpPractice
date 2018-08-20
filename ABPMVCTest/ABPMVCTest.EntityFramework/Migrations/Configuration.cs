using System.Data.Entity.Migrations;
using ABPMVCTest.Migrations.SeedData;

namespace ABPMVCTest.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ABPMVCTest.EntityFramework.ABPMVCTestDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ABPMVCTest";
        }

        protected override void Seed(ABPMVCTest.EntityFramework.ABPMVCTestDbContext context)
        {
            new InitialDataBuilder(context).Build();
        }
    }
}
