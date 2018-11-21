namespace Daybook.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADD_ACTIVITYLOGRELATION1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("usrdata.ActivityLogRelations", new[] { "Planning_PlanningID", "Planning_UserID" }, "usrdata.Plannings");
            DropForeignKey("usrdata.ActivityLogRelations", new[] { "USRBookCategory_CategoryID", "USRBookCategory_UserID" }, "usrdata.USRBookCategories");
            DropIndex("usrdata.ActivityLogRelations", new[] { "Planning_PlanningID", "Planning_UserID" });
            DropIndex("usrdata.ActivityLogRelations", new[] { "USRBookCategory_CategoryID", "USRBookCategory_UserID" });
            DropColumn("usrdata.ActivityLogRelations", "Planning_PlanningID");
            DropColumn("usrdata.ActivityLogRelations", "Planning_UserID");
            DropColumn("usrdata.ActivityLogRelations", "USRBookCategory_CategoryID");
            DropColumn("usrdata.ActivityLogRelations", "USRBookCategory_UserID");
        }
        
        public override void Down()
        {
            AddColumn("usrdata.ActivityLogRelations", "USRBookCategory_UserID", c => c.String(maxLength: 128));
            AddColumn("usrdata.ActivityLogRelations", "USRBookCategory_CategoryID", c => c.String(maxLength: 50, unicode: false));
            AddColumn("usrdata.ActivityLogRelations", "Planning_UserID", c => c.String(maxLength: 128));
            AddColumn("usrdata.ActivityLogRelations", "Planning_PlanningID", c => c.String(maxLength: 50, unicode: false));
            CreateIndex("usrdata.ActivityLogRelations", new[] { "USRBookCategory_CategoryID", "USRBookCategory_UserID" });
            CreateIndex("usrdata.ActivityLogRelations", new[] { "Planning_PlanningID", "Planning_UserID" });
            AddForeignKey("usrdata.ActivityLogRelations", new[] { "USRBookCategory_CategoryID", "USRBookCategory_UserID" }, "usrdata.USRBookCategories", new[] { "CategoryID", "UserID" });
            AddForeignKey("usrdata.ActivityLogRelations", new[] { "Planning_PlanningID", "Planning_UserID" }, "usrdata.Plannings", new[] { "PlanningID", "UserID" });
        }
    }
}
