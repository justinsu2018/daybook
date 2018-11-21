namespace Daybook.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADD_CURRENCYID_PLANNINGID_ActivityLog : DbMigration
    {
        public override void Up()
        {
            AddColumn("usrdata.ActiveLogs", "USRBookCategoryID", c => c.String());
            AddColumn("usrdata.ActiveLogs", "USRBookCategory_CategoryID", c => c.String(maxLength: 50, unicode: false));
            AddColumn("usrdata.ActiveLogs", "USRBookCategory_UserID", c => c.String(maxLength: 128));
            CreateIndex("usrdata.ActiveLogs", new[] { "USRBookCategory_CategoryID", "USRBookCategory_UserID" });
            AddForeignKey("usrdata.ActiveLogs", new[] { "USRBookCategory_CategoryID", "USRBookCategory_UserID" }, "usrdata.USRBookCategories", new[] { "CategoryID", "UserID" });
        }
        
        public override void Down()
        {
            DropForeignKey("usrdata.ActiveLogs", new[] { "USRBookCategory_CategoryID", "USRBookCategory_UserID" }, "usrdata.USRBookCategories");
            DropIndex("usrdata.ActiveLogs", new[] { "USRBookCategory_CategoryID", "USRBookCategory_UserID" });
            DropColumn("usrdata.ActiveLogs", "USRBookCategory_UserID");
            DropColumn("usrdata.ActiveLogs", "USRBookCategory_CategoryID");
            DropColumn("usrdata.ActiveLogs", "USRBookCategoryID");
        }
    }
}
