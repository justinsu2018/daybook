using Daybook.Core.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Daybook.WebApp.Core.ViewModels
{
    public class PlanFormViewModel : BaseEntity
    {
        public string PlanningID { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "Name")]
        public string PlanningName { get; set; }

        [Display(Name = "Due Date")]
        [RegularExpression(@"\d{4}\\(?:0[1-9]|1[0-2])", ErrorMessage = @"Due Date must be yyyy\MM")]
        public string DueDate { get; set; }

        [Required]
        [Display(Name = "Currency")]
        public string CurrencyID { get; set; }

        public IEnumerable<USRCurrency> Currencies { get; set; }

        [Required]
        [Display(Name = "Amount")]
        [RegularExpression(@"\d", ErrorMessage = @"Amount must be numeric")]
        public float RecentBaalance { get; set; }

        public string CategroyID { get; set; }

        public string ItemID { get; set; }
    }
}