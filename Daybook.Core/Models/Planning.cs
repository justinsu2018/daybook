namespace Daybook.Core.Models
{
    public class Planning : BaseEntity
    {
        public string PlanningID { get; set; }

        public PlanKind PlanKind { get; set; }

        public string PlanningName { get; set; }

        public string DueDate { get; set; }

        public string CurrencyID { get; set; }

        public float RecentBalance { get; set; }

        public float RecentAmount { get; set; }

        public float ArchivesRate { get; set; }

        public string CategoryID { get; set; }

        public string ItemID { get; set; }

        public string UserID { get; set; }

        public ApplicationUser User { get; set; }
    }
}
