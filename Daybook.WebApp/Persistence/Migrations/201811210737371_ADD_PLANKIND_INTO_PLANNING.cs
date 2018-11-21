namespace Daybook.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADD_PLANKIND_INTO_PLANNING : DbMigration
    {
        public override void Up()
        {
            AddColumn("usrdata.Plannings", "PlanKind", c => c.Short());
        }
        
        public override void Down()
        {
            DropColumn("usrdata.Plannings", "PlanKind");
        }
    }
}
