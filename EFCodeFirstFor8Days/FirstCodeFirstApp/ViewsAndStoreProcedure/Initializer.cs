using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewsAndStoreProcedure
{
    public class Initializer:DropCreateDatabaseIfModelChanges<DonatorsContext>
    {
        protected override void Seed(DonatorsContext context)
        {
            var drop = "Drop Table DonatorViews";
            context.Database.ExecuteSqlCommand(drop);
            var createView = @"CREATE VIEW [dbo].[DonatorViews]
	                            AS SELECT 
	                            dbo.Donators.Id AS DonatorId,
	                            dbo.Donators.Name AS DonatorName,
	                            dbo.Donators.Amount AS Amount,
	                            dbo.Donators.DonateDate AS DonateDate,
	                            dbo.Provinces.ProvinceName AS ProvinceName
	                            FROM dbo.Donators
	                            INNER JOIN dbo.Provinces ON dbo.Provinces.Id = dbo.Donators.ProvinceId";
            context.Database.ExecuteSqlCommand(createView);
        }
    }
}
