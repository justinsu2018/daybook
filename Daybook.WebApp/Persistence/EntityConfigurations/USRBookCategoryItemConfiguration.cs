using Daybook.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Daybook.WebApp.Persistence.EntityConfigurations
{
    public class USRBookCategoryItemConfiguration : EntityTypeConfiguration<USRBookCategoryItem>
    {
        public USRBookCategoryItemConfiguration()
        {
            ToTable("USRBookCategoryItems", "usrdata");

            Property(sbci => sbci.ItemID)
                .HasColumnOrder(1)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(sbci => sbci.CategoryID)
                .HasColumnOrder(2)
                .IsRequired()
                .IsUnicode(true);

            Property(sbci => sbci.ItemName)
                .HasColumnType("nvarchar")
                .HasMaxLength(255)
                .IsRequired();

            HasKey(sbci => new { sbci.CategoryID, sbci.ItemID, sbci.UserID });
        }
    }
}