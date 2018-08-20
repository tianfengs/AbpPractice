namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Donator_Add_CreationTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Donators", "CreationTime", c => c.DateTime(nullable: false,defaultValueSql:"GetDate()"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Donators", "CreationTime");
        }
    }
}
