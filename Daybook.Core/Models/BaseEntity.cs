using System;

namespace Daybook.Core.Models
{
    [Serializable]
    public class BaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
