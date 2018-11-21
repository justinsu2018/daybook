namespace Daybook.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADD_RecentAmount_And_ArchivesRate_INTO_PLANNING : DbMigration
    {
        public override void Up()
        {
            AddColumn("usrdata.Plannings", "RecentAmount", c => c.Single(nullable: false));
            AddColumn("usrdata.Plannings", "ArchivesRate", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("usrdata.Plannings", "ArchivesRate");
            DropColumn("usrdata.Plannings", "RecentAmount");
        }
    }
}
