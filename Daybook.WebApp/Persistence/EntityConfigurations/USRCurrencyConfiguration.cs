using Daybook.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Daybook.WebApp.Persistence.EntityConfigurations
{
    public class USRCurrencyConfiguration: EntityTypeConfiguration<USRCurrency>
    {
        public USRCurrencyConfiguration()
        {
            ToTable("USRCurrency", "usrdata");

            Property(c => c.Name)
                .HasColumnType("nvarchar")
                .HasMaxLength(255)
                .IsRequired()
                .IsUnicode(true);

            Property(c => c.CurrencyID)
                .HasColumnType("varchar")
                .HasMaxLength(3);

            HasKey(c => c.CurrencyID);
        }
    }
}