namespace Daybook.Core.Models
{
    public class SYSBookCategoryItem
    {
        public string ItemID { get; set; }

        public string ItemName { get; set; }

        public string CategoryID { get; set; }

        public SYSBookCategory BookCategory { get; set; }
    }
}
