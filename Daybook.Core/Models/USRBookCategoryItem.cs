namespace Daybook.Core.Models
{
    public class USRBookCategoryItem
    {
        public string ItemID { get; set; }

        public string ItemName { get; set; }

        public string CategoryID { get; set; }

        public USRBookCategory BookCategory { get; set; }

        public string UserID { get; set; }

        public ApplicationUser User { get; set; }
    }
}
