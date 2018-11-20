using Daybook.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Daybook.WebApp.Persistence.EntityConfigurations
{
    public class PlanningConfiguration : EntityTypeConfiguration<Planning>
    {
        public PlanningConfiguration()
        {
            ToTable("Plannings", "usrdata");

            Property(p => p.PlanningID)
                .HasColumnType("varchar")
                .HasMaxLength(50);

            Property(p => p.CurrencyID)
                .HasColumnType("varchar")
                .HasMaxLength(50);

            Property(p => p.DueDate)
                .HasColumnType("char")
                .HasMaxLength(7);

            Property(p => p.ItemID)
                .HasColumnType("varchar")
                .HasMaxLength(50);

            Property(p => p.PlanningName)
                .HasColumnType("nvarchar")
                .HasMaxLength(255)
                .IsUnicode(true);

            HasKey(p => new { p.PlanningID, p.UserID });
                

    //        HasMany(gc => gc.CategoryItems)
    //.WithRequired(gci => gci.BookCategory)
    //.WillCascadeOnDelete(false);
        }
    }
}