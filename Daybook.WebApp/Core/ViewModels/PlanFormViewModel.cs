using Daybook.Core.Models;
using Daybook.WebApp.Core.ViewModels.Validations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Daybook.WebApp.Core.ViewModels
{
    public class PlanFormViewModel : BaseEntity
    {
        public string PlanningID { get; set; }

        [Display(Name ="Play Type")]
        public PlanKind PlanKind { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "Name")]
        public string PlanningName { get; set; }

        [Display(Name = "Due Date")]
        [FutureDateValidation(ErrorMessage = "Only accept future dates")]
        [RegularExpression(@"\d{4}/(?:0[1-9]|1[0-2])", ErrorMessage = @"Due Date must be yyyy/MM")]
        public string DueDate { get; set; }

        [Required]
        [Display(Name = "Currency")]
        public string CurrencyID { get; set; }

        public IEnumerable<USRCurrency> Currencies { get; set; }

        [Required]
        [Display(Name = "Amount")]
        [AmountValidation(ErrorMessage = "Only accept positive numbers or postive number with two decimal points")]
        public float RecentBalance { get; set; }

        public string CategroyID { get; set; }

        public string ItemID { get; set; }
    }
}