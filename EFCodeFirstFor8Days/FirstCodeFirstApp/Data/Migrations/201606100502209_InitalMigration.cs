namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Donators",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 10),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DonateDate = c.DateTime(nullable: false),
                        ProvinceId = c.Int(nullable: false),
                        Message = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Provinces", t => t.ProvinceId, cascadeDelete: true)
                .Index(t => t.ProvinceId);
            
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Donators", "ProvinceId", "dbo.Provinces");
            DropIndex("dbo.Donators", new[] { "ProvinceId" });
            DropTable("dbo.Provinces");
            DropTable("dbo.Donators");
        }
    }
}
