using System.Collections.Generic;

namespace Daybook.Core.Models
{
    public class USRBookCategory
    {
        public string CategoryID { get; set; }
        public string CategoryName { get; set; } //nvarchar(155)

        public ICollection<USRBookCategoryItem> CategoryItems { get; set; }

        public string UserID { get; set; }
        public ApplicationUser User { get; set; }
    }
}
