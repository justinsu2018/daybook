using Daybook.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Daybook.WebApp.Persistence.EntityConfigurations
{
    public class WorkingGroupMemberConfiguration : EntityTypeConfiguration<WorkingGroupMember>
    {
        public WorkingGroupMemberConfiguration()
        {
            ToTable("WorkingGroupMembers", "usrdata");

            Property(wgi => wgi.GroupID)
                .HasColumnType("varchar")
                .HasMaxLength(50);

            Property(wgi => wgi.Email)
                .HasColumnType("varchar")
                .HasMaxLength(255)
                .IsRequired()
                .IsUnicode(true);

            HasKey(wgi => new { wgi.MemberID, wgi.GroupID });
        }
    }
}