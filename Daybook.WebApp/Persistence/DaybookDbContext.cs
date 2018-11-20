using Daybook.Core.Models;
using Daybook.WebApp.Persistence.EntityConfigurations;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using ApplicationUser = Daybook.Core.Models.ApplicationUser;

namespace Daybook.WebApp.Persistence
{
    public class DaybookDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<SYSBookCategory> SYSBookCategories { get; set; }
        public DbSet<SYSBookCategoryItem> SYSBookCategoryItems { get; set; }

        public DbSet<USRBookCategory> USRBookCategories { get; set; }
        public DbSet<USRBookCategoryItem> USRBookCategoryItems { get; set; }
        public DbSet<Payee> Payees { get; set; }
        public DbSet<WorkingGroup> WorkingGroups { get; set; }
        public DbSet<WorkingGroupMember> WorkingGroupMembers { get; set; }
        public DbSet<Planning> Plannings { get; set; }
        public DbSet<USRCurrency> USRCurrencies { get; set; }

        public DaybookDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            //Database.SetInitializer(new DaybookDBInitializer());
        }

        public static DaybookDbContext Create()
        {
            return new DaybookDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("sysdata");

            modelBuilder.Configurations.Add(new SYSBookCategoryConfiguration());
            modelBuilder.Configurations.Add(new SYSBookCategoryItemConfiguration());

            modelBuilder.Configurations.Add(new USRBookCategoryConfiguration());
            modelBuilder.Configurations.Add(new USRBookCategoryItemConfiguration());
            modelBuilder.Configurations.Add(new USRCurrencyConfiguration());

            modelBuilder.Configurations.Add(new PayeeConfiguration());
            modelBuilder.Configurations.Add(new WorkingGroupConfiguration());
            modelBuilder.Configurations.Add(new WorkingGroupMemberConfiguration());
            modelBuilder.Configurations.Add(new PlanningConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}