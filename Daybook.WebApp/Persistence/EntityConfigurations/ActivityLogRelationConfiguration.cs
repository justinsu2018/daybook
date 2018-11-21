using Daybook.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Daybook.WebApp.Persistence.EntityConfigurations
{
    public class ActivityLogRelationConfiguration : EntityTypeConfiguration<ActivityLogRelation>
    {
        public ActivityLogRelationConfiguration()
        {
            ToTable("ActivityLogRelations", "usrdata");

            HasKey(alr => new { alr.RelationID, alr.PlanningID });
        }
    }
}