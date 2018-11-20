using System;

namespace Daybook.Core.Models
{
    public class ActivityLog
    {
        public string LogID { get; set; }

        public DateTime LogDate { get; set; }

        public ActivityType ActivityType {get; set;}

        public float Income { get; set; }
        
        public float Expense { get; set; }

        public string UserID { get; set; }
        public ApplicationUser User { get; set; }

        public string PlanningID { get; set; }
        public Planning Planning { get;  set; }
        
    }
}
