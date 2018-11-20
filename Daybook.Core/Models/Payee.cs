namespace Daybook.Core.Models
{
    public class Payee
    {
        public string PayeeID { get; set; }
        public string PayeeName { get; set; }

        public string UserID { get; set; }
        public ApplicationUser User { get; set; }
    }
}
