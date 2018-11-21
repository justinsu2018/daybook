namespace Daybook.Core.Models
{
    public class ActivityLogRelation
    {
        public string RelationID { get; set; }

        public string PlanningID { get; set; }

        public string USRBookCategoryID { get; set; }

        public ActivityLog ActivityLog { get; set; }
    }
}
