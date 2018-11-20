using System.ComponentModel.DataAnnotations;

namespace Daybook.WebApp.Core.ViewModels
{
    public class PayeeFormViewModel
    {
        public string PayeeID { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "Payee Name")]
        public string PayeeName { get; set; }
    }
}