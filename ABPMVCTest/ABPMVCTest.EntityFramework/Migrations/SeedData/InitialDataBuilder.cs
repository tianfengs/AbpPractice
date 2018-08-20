using ABPMVCTest.EntityFramework;
using EntityFramework.DynamicFilters;

namespace ABPMVCTest.Migrations.SeedData
{
    public class InitialDataBuilder
    {
        private readonly ABPMVCTestDbContext _context;

        public InitialDataBuilder(ABPMVCTestDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            _context.DisableAllFilters();

            new DefaultEditionsBuilder(_context).Build();
            new DefaultTenantRoleAndUserBuilder(_context).Build();
            new DefaultLanguagesBuilder(_context).Build();
        }
    }
}
