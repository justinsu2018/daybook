using Daybook.Core.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Daybook.WebApp.Core.ViewModels
{
    public class UserProfileFormViewModel
    {
        [Required]
        [MaxLength(255)]
        [Display(Name = "Your Name")]
        public string NickName { get; set; }

        [Display(Name = "Currency")]
        public string PrimaryCurrency { get; set; }

        public IEnumerable<USRCurrency> USRCurrencies { get; set; }
    }
}