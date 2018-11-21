namespace Daybook.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADD_ACTIVITYLOGRELATION : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("usrdata.ActiveLogs", new[] { "PlanningID", "UserID" }, "usrdata.Plannings");
            DropForeignKey("usrdata.ActiveLogs", new[] { "USRBookCategory_CategoryID", "USRBookCategory_UserID" }, "usrdata.USRBookCategories");
            DropForeignKey("usrdata.ActiveLogs", "UserID", "sysdata.AspNetUsers");
            DropIndex("usrdata.ActiveLogs", new[] { "PlanningID", "UserID" });
            DropIndex("usrdata.ActiveLogs", new[] { "USRBookCategory_CategoryID", "USRBookCategory_UserID" });
            DropPrimaryKey("usrdata.ActiveLogs");
            CreateTable(
                "usrdata.ActivityLogRelations",
                c => new
                    {
                        RelationID = c.String(nullable: false, maxLength: 128),
                        PlanningID = c.String(nullable: false, maxLength: 128),
                        USRBookCategoryID = c.String(),
                        Planning_PlanningID = c.String(maxLength: 50, unicode: false),
                        Planning_UserID = c.String(maxLength: 128),
                        USRBookCategory_CategoryID = c.String(maxLength: 50, unicode: false),
                        USRBookCategory_UserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RelationID, t.PlanningID })
                .ForeignKey("usrdata.ActiveLogs", t => new { t.RelationID, t.PlanningID })
                .ForeignKey("usrdata.Plannings", t => new { t.Planning_PlanningID, t.Planning_UserID })
                .ForeignKey("usrdata.USRBookCategories", t => new { t.USRBookCategory_CategoryID, t.USRBookCategory_UserID })
                .Index(t => new { t.RelationID, t.PlanningID })
                .Index(t => new { t.Planning_PlanningID, t.Planning_UserID })
                .Index(t => new { t.USRBookCategory_CategoryID, t.USRBookCategory_UserID });
            
            AlterColumn("usrdata.ActiveLogs", "UserID", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("usrdata.ActiveLogs", new[] { "LogID", "UserID" });
            CreateIndex("usrdata.ActiveLogs", "UserID");
            AddForeignKey("usrdata.ActiveLogs", "UserID", "sysdata.AspNetUsers", "Id", cascadeDelete: true);
            DropColumn("usrdata.ActiveLogs", "PlanningID");
            DropColumn("usrdata.ActiveLogs", "USRBookCategoryID");
            DropColumn("usrdata.ActiveLogs", "USRBookCategory_CategoryID");
            DropColumn("usrdata.ActiveLogs", "USRBookCategory_UserID");
        }
        
        public override void Down()
        {
            AddColumn("usrdata.ActiveLogs", "USRBookCategory_UserID", c => c.String(maxLength: 128));
            AddColumn("usrdata.ActiveLogs", "USRBookCategory_CategoryID", c => c.String(maxLength: 50, unicode: false));
            AddColumn("usrdata.ActiveLogs", "USRBookCategoryID", c => c.String());
            AddColumn("usrdata.ActiveLogs", "PlanningID", c => c.String(maxLength: 50, unicode: false));
            DropForeignKey("usrdata.ActiveLogs", "UserID", "sysdata.AspNetUsers");
            DropForeignKey("usrdata.ActivityLogRelations", new[] { "USRBookCategory_CategoryID", "USRBookCategory_UserID" }, "usrdata.USRBookCategories");
            DropForeignKey("usrdata.ActivityLogRelations", new[] { "Planning_PlanningID", "Planning_UserID" }, "usrdata.Plannings");
            DropForeignKey("usrdata.ActivityLogRelations", new[] { "RelationID", "PlanningID" }, "usrdata.ActiveLogs");
            DropIndex("usrdata.ActiveLogs", new[] { "UserID" });
            DropIndex("usrdata.ActivityLogRelations", new[] { "USRBookCategory_CategoryID", "USRBookCategory_UserID" });
            DropIndex("usrdata.ActivityLogRelations", new[] { "Planning_PlanningID", "Planning_UserID" });
            DropIndex("usrdata.ActivityLogRelations", new[] { "RelationID", "PlanningID" });
            DropPrimaryKey("usrdata.ActiveLogs");
            AlterColumn("usrdata.ActiveLogs", "UserID", c => c.String(maxLength: 128));
            DropTable("usrdata.ActivityLogRelations");
            AddPrimaryKey("usrdata.ActiveLogs", "LogID");
            CreateIndex("usrdata.ActiveLogs", new[] { "USRBookCategory_CategoryID", "USRBookCategory_UserID" });
            CreateIndex("usrdata.ActiveLogs", new[] { "PlanningID", "UserID" });
            AddForeignKey("usrdata.ActiveLogs", "UserID", "sysdata.AspNetUsers", "Id");
            AddForeignKey("usrdata.ActiveLogs", new[] { "USRBookCategory_CategoryID", "USRBookCategory_UserID" }, "usrdata.USRBookCategories", new[] { "CategoryID", "UserID" });
            AddForeignKey("usrdata.ActiveLogs", new[] { "PlanningID", "UserID" }, "usrdata.Plannings", new[] { "PlanningID", "UserID" });
        }
    }
}
