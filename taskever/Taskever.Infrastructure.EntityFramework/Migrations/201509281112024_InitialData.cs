namespace Taskever.Infrastructure.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AbpUsers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProfileImage = c.String(),
                        TenantId = c.Int(),
                        UserName = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                        EmailAddress = c.String(),
                        IsEmailConfirmed = c.Boolean(nullable: false),
                        EmailConfirmationCode = c.String(),
                        Password = c.String(),
                        PasswordResetCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TeActivities",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AssignedUserId = c.Long(nullable: false),
                        TaskId = c.Int(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        ActivityType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TeTasks", t => t.TaskId)
                .ForeignKey("dbo.AbpUsers", t => t.CreatorUserId)
                .Index(t => t.TaskId)
                .Index(t => t.CreatorUserId);
            
            CreateTable(
                "dbo.TeTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        AssignedUserId = c.Long(),
                        Priority = c.Byte(nullable: false),
                        Privacy = c.Byte(nullable: false),
                        State = c.Byte(nullable: false),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpUsers", t => t.AssignedUserId)
                .Index(t => t.AssignedUserId);
            
            CreateTable(
                "dbo.TeFriendships",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Long(nullable: false),
                        FriendUserId = c.Long(nullable: false),
                        PairFriendshipId = c.Int(nullable: false),
                        FollowActivities = c.Boolean(nullable: false),
                        CanAssignTask = c.Boolean(nullable: false),
                        Status = c.Int(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        LastVisitTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpUsers", t => t.FriendUserId)
                .ForeignKey("dbo.TeFriendships", t => t.PairFriendshipId)
                .ForeignKey("dbo.AbpUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.FriendUserId)
                .Index(t => t.PairFriendshipId);
            
            CreateTable(
                "dbo.TeUserFollowedActivities",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IsActor = c.Boolean(nullable: false),
                        IsRelated = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        Activity_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TeActivities", t => t.Activity_Id)
                .Index(t => t.Activity_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeUserFollowedActivities", "Activity_Id", "dbo.TeActivities");
            DropForeignKey("dbo.TeFriendships", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.TeFriendships", "PairFriendshipId", "dbo.TeFriendships");
            DropForeignKey("dbo.TeFriendships", "FriendUserId", "dbo.AbpUsers");
            DropForeignKey("dbo.TeActivities", "CreatorUserId", "dbo.AbpUsers");
            DropForeignKey("dbo.TeActivities", "TaskId", "dbo.TeTasks");
            DropForeignKey("dbo.TeTasks", "AssignedUserId", "dbo.AbpUsers");
            DropIndex("dbo.TeUserFollowedActivities", new[] { "Activity_Id" });
            DropIndex("dbo.TeFriendships", new[] { "PairFriendshipId" });
            DropIndex("dbo.TeFriendships", new[] { "FriendUserId" });
            DropIndex("dbo.TeFriendships", new[] { "UserId" });
            DropIndex("dbo.TeTasks", new[] { "AssignedUserId" });
            DropIndex("dbo.TeActivities", new[] { "CreatorUserId" });
            DropIndex("dbo.TeActivities", new[] { "TaskId" });
            DropTable("dbo.TeUserFollowedActivities");
            DropTable("dbo.TeFriendships");
            DropTable("dbo.TeTasks");
            DropTable("dbo.TeActivities");
            DropTable("dbo.AbpUsers");
        }
    }
}
