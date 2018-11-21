namespace Daybook.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADD_ACTIVITYLOGRELATION2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("usrdata.ActiveLogs", "UserID", "sysdata.AspNetUsers");
            DropIndex("usrdata.ActiveLogs", new[] { "UserID" });
            AddColumn("usrdata.ActiveLogs", "CurrencyID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("usrdata.ActiveLogs", "CurrencyID");
            CreateIndex("usrdata.ActiveLogs", "UserID");
            AddForeignKey("usrdata.ActiveLogs", "UserID", "sysdata.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
