using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Daybook.Core.Models
{
    public class WorkingGroup : BaseEntity
    {
        public string GroupID { get; set; }

        public string GroupName { get; set; }

        public string UserID { get; set; }
        public ApplicationUser User { get; set; }

        public ICollection<WorkingGroupMember> WorkingGroupMembers { get; set; }

        public WorkingGroup()
        {
            WorkingGroupMembers = new Collection<WorkingGroupMember>();
        }
    }
}
