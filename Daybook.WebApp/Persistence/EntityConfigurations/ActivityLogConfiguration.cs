using Daybook.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Daybook.WebApp.Persistence.EntityConfigurations
{
    public class ActivityLogConfiguration : EntityTypeConfiguration<ActivityLog>
    {
        public ActivityLogConfiguration()
        {
            ToTable("ActiveLogs", "usrdata");

            HasKey(al => new { al.LogID, al.UserID });
        }
    }
}