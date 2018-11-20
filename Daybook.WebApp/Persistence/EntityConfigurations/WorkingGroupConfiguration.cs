using Daybook.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Daybook.WebApp.Persistence.EntityConfigurations
{
    public class WorkingGroupConfiguration : EntityTypeConfiguration<WorkingGroup>
    {
        public WorkingGroupConfiguration()
        {
            ToTable("WorkingGroups", "usrdata");

            Property(wg => wg.GroupID)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .HasColumnOrder(1);

            Property(wg => wg.UserID)
                .HasColumnOrder(2);

            Property(wg => wg.GroupName)
                .HasColumnName("nvarchar")
                .HasMaxLength(255)
                .IsRequired()
                .IsUnicode(true);

            HasKey(wg => new { wg.GroupID, wg.UserID })
                .HasMany(wg => wg.WorkingGroupMembers)
                .WithRequired(wgi => wgi.WorkingGroup)
                .WillCascadeOnDelete(false);
        }
    }
}