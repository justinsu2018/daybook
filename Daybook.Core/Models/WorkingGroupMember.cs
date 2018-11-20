namespace Daybook.Core.Models
{
    public class WorkingGroupMember : BaseEntity
    {
        public string MemberID { get; set; }

        public string Email { get; set; }

        public bool IsAccepted { get; set; }

        public string GroupID { get; set; }
        public WorkingGroup WorkingGroup { get; set; }
    }
}
