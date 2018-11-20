using Daybook.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Daybook.WebApp.Persistence.EntityConfigurations
{
    public class SYSBookCategoryConfiguration : EntityTypeConfiguration<SYSBookCategory>
    {
        public SYSBookCategoryConfiguration()
        {
            ToTable("SYSBookCategories", "sysdata");

            Property(gc => gc.CategoryID)
                .HasColumnType("varchar")
                .HasMaxLength(50);

            Property(gc => gc.CategoryName)
                .HasColumnType("nvarchar")
                .HasMaxLength(255)
                .IsRequired()
                .IsUnicode(true);

            HasKey(gc => gc.CategoryID);

            HasMany(gc => gc.CategoryItems)
                .WithRequired(gci => gci.BookCategory)
                .WillCascadeOnDelete(false);
        }
    }
}