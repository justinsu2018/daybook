using Daybook.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Daybook.WebApp.Persistence.EntityConfigurations
{
    public class USRBookCategoryConfiguration : EntityTypeConfiguration<USRBookCategory>
    {
        public USRBookCategoryConfiguration()
        {
            ToTable("USRBookCategories", "usrdata");

            Property(u => u.CategoryID)
                .HasColumnType("varchar")
                .HasMaxLength(50);

            Property(u => u.CategoryName)
                .HasColumnType("nvarchar")
                .HasMaxLength(255)
                .IsRequired()
                .IsUnicode(true);

            HasKey(u => new { u.CategoryID, u.UserID });

            HasMany(u => u.CategoryItems)
                .WithRequired(ui => ui.BookCategory)
                .WillCascadeOnDelete(false);
        }
    }
}