namespace Daybook.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADD_ActivityLog1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "usrdata.ActiveLogs",
                c => new
                    {
                        LogID = c.String(nullable: false, maxLength: 128),
                        LogDate = c.DateTime(nullable: false),
                        ActivityType = c.Byte(nullable: false),
                        Income = c.Single(nullable: false),
                        Expense = c.Single(nullable: false),
                        UserID = c.String(maxLength: 128),
                        PlanningID = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.LogID)
                .ForeignKey("usrdata.Plannings", t => new { t.PlanningID, t.UserID })
                .ForeignKey("sysdata.AspNetUsers", t => t.UserID)
                .Index(t => new { t.PlanningID, t.UserID });
            
        }
        
        public override void Down()
        {
            DropForeignKey("usrdata.ActiveLogs", "UserID", "sysdata.AspNetUsers");
            DropForeignKey("usrdata.ActiveLogs", new[] { "PlanningID", "UserID" }, "usrdata.Plannings");
            DropIndex("usrdata.ActiveLogs", new[] { "PlanningID", "UserID" });
            DropTable("usrdata.ActiveLogs");
        }
    }
}
