using Daybook.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Daybook.WebApp.Persistence.EntityConfigurations
{
    public class PayeeConfiguration : EntityTypeConfiguration<Payee>
    {
        public PayeeConfiguration()
        {
            ToTable("Payees", "usrdata");

            Property(p => p.PayeeName)
                .HasColumnType("nvarchar")
                .HasMaxLength(255)
                .IsRequired()
                .IsUnicode(true);

            //HasKey(p => new { p.PayeeID, p.UserID });
            HasKey(p => new { p.PayeeID, p.UserID });
        }
    }
}