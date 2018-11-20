namespace Daybook.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Daybook : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "usrdata.Payees",
                c => new
                    {
                        PayeeID = c.String(nullable: false, maxLength: 128),
                        UserID = c.String(nullable: false, maxLength: 128),
                        PayeeName = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => new { t.PayeeID, t.UserID })
                .ForeignKey("sysdata.AspNetUsers", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "sysdata.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        NickName = c.String(nullable: false, maxLength: 255),
                        MemberType = c.Byte(nullable: false),
                        SubscriptedType = c.Short(nullable: false),
                        StartDate = c.DateTime(),
                        DueDate = c.DateTime(),
                        CurrencyID = c.String(maxLength: 3),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "sysdata.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("sysdata.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "sysdata.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("sysdata.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "usrdata.Plannings",
                c => new
                    {
                        PlanningID = c.String(nullable: false, maxLength: 50, unicode: false),
                        UserID = c.String(nullable: false, maxLength: 128),
                        PlanningName = c.String(maxLength: 255),
                        DueDate = c.String(maxLength: 7, fixedLength: true, unicode: false),
                        CurrencyID = c.String(maxLength: 50, unicode: false),
                        RecentBalance = c.Single(nullable: false),
                        CategoryID = c.String(),
                        ItemID = c.String(maxLength: 50, unicode: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => new { t.PlanningID, t.UserID })
                .ForeignKey("sysdata.AspNetUsers", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "sysdata.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("sysdata.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("sysdata.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "usrdata.USRBookCategories",
                c => new
                    {
                        CategoryID = c.String(nullable: false, maxLength: 50, unicode: false),
                        UserID = c.String(nullable: false, maxLength: 128),
                        CategoryName = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => new { t.CategoryID, t.UserID })
                .ForeignKey("sysdata.AspNetUsers", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "usrdata.USRBookCategoryItems",
                c => new
                    {
                        ItemID = c.String(nullable: false, maxLength: 50, unicode: false),
                        CategoryID = c.String(nullable: false, maxLength: 50, unicode: false),
                        UserID = c.String(nullable: false, maxLength: 128),
                        ItemName = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => new { t.ItemID, t.CategoryID, t.UserID })
                .ForeignKey("sysdata.AspNetUsers", t => t.UserID, cascadeDelete: true)
                .ForeignKey("usrdata.USRBookCategories", t => new { t.CategoryID, t.UserID })
                .Index(t => new { t.CategoryID, t.UserID })
                .Index(t => t.UserID);
            
            CreateTable(
                "usrdata.USRCurrency",
                c => new
                    {
                        CurrencyID = c.String(nullable: false, maxLength: 3, unicode: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CurrencyID)
                .ForeignKey("sysdata.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "usrdata.WorkingGroups",
                c => new
                    {
                        GroupID = c.String(nullable: false, maxLength: 50, unicode: false),
                        UserID = c.String(nullable: false, maxLength: 128),
                        nvarchar = c.String(nullable: false, maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => new { t.GroupID, t.UserID })
                .ForeignKey("sysdata.AspNetUsers", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "usrdata.WorkingGroupMembers",
                c => new
                    {
                        MemberID = c.String(nullable: false, maxLength: 128),
                        GroupID = c.String(nullable: false, maxLength: 50, unicode: false),
                        Email = c.String(nullable: false, maxLength: 255, unicode: false),
                        IsAccepted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(),
                        WorkingGroup_GroupID = c.String(nullable: false, maxLength: 50, unicode: false),
                        WorkingGroup_UserID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.MemberID, t.GroupID })
                .ForeignKey("usrdata.WorkingGroups", t => new { t.WorkingGroup_GroupID, t.WorkingGroup_UserID })
                .Index(t => new { t.WorkingGroup_GroupID, t.WorkingGroup_UserID });
            
            CreateTable(
                "sysdata.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "sysdata.SYSBookCategories",
                c => new
                    {
                        CategoryID = c.String(nullable: false, maxLength: 50, unicode: false),
                        CategoryName = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "sysdata.SYSBookCategoryItems",
                c => new
                    {
                        ItemID = c.String(nullable: false, maxLength: 50, unicode: false),
                        CategoryID = c.String(nullable: false, maxLength: 50, unicode: false),
                        ItemName = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => new { t.ItemID, t.CategoryID })
                .ForeignKey("sysdata.SYSBookCategories", t => t.CategoryID)
                .Index(t => t.CategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("sysdata.SYSBookCategoryItems", "CategoryID", "sysdata.SYSBookCategories");
            DropForeignKey("sysdata.AspNetUserRoles", "RoleId", "sysdata.AspNetRoles");
            DropForeignKey("usrdata.WorkingGroupMembers", new[] { "WorkingGroup_GroupID", "WorkingGroup_UserID" }, "usrdata.WorkingGroups");
            DropForeignKey("usrdata.WorkingGroups", "UserID", "sysdata.AspNetUsers");
            DropForeignKey("usrdata.USRCurrency", "ApplicationUser_Id", "sysdata.AspNetUsers");
            DropForeignKey("usrdata.USRBookCategories", "UserID", "sysdata.AspNetUsers");
            DropForeignKey("usrdata.USRBookCategoryItems", new[] { "CategoryID", "UserID" }, "usrdata.USRBookCategories");
            DropForeignKey("usrdata.USRBookCategoryItems", "UserID", "sysdata.AspNetUsers");
            DropForeignKey("sysdata.AspNetUserRoles", "UserId", "sysdata.AspNetUsers");
            DropForeignKey("usrdata.Plannings", "UserID", "sysdata.AspNetUsers");
            DropForeignKey("usrdata.Payees", "UserID", "sysdata.AspNetUsers");
            DropForeignKey("sysdata.AspNetUserLogins", "UserId", "sysdata.AspNetUsers");
            DropForeignKey("sysdata.AspNetUserClaims", "UserId", "sysdata.AspNetUsers");
            DropIndex("sysdata.SYSBookCategoryItems", new[] { "CategoryID" });
            DropIndex("sysdata.AspNetRoles", "RoleNameIndex");
            DropIndex("usrdata.WorkingGroupMembers", new[] { "WorkingGroup_GroupID", "WorkingGroup_UserID" });
            DropIndex("usrdata.WorkingGroups", new[] { "UserID" });
            DropIndex("usrdata.USRCurrency", new[] { "ApplicationUser_Id" });
            DropIndex("usrdata.USRBookCategoryItems", new[] { "UserID" });
            DropIndex("usrdata.USRBookCategoryItems", new[] { "CategoryID", "UserID" });
            DropIndex("usrdata.USRBookCategories", new[] { "UserID" });
            DropIndex("sysdata.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("sysdata.AspNetUserRoles", new[] { "UserId" });
            DropIndex("usrdata.Plannings", new[] { "UserID" });
            DropIndex("sysdata.AspNetUserLogins", new[] { "UserId" });
            DropIndex("sysdata.AspNetUserClaims", new[] { "UserId" });
            DropIndex("sysdata.AspNetUsers", "UserNameIndex");
            DropIndex("usrdata.Payees", new[] { "UserID" });
            DropTable("sysdata.SYSBookCategoryItems");
            DropTable("sysdata.SYSBookCategories");
            DropTable("sysdata.AspNetRoles");
            DropTable("usrdata.WorkingGroupMembers");
            DropTable("usrdata.WorkingGroups");
            DropTable("usrdata.USRCurrency");
            DropTable("usrdata.USRBookCategoryItems");
            DropTable("usrdata.USRBookCategories");
            DropTable("sysdata.AspNetUserRoles");
            DropTable("usrdata.Plannings");
            DropTable("sysdata.AspNetUserLogins");
            DropTable("sysdata.AspNetUserClaims");
            DropTable("sysdata.AspNetUsers");
            DropTable("usrdata.Payees");
        }
    }
}
