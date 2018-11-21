using Daybook.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Daybook.WebApp.Core.ViewModels
{
    public class ActivityLogFormViewModel
    {
        public string LogID { get; set; }
        
        [Required]
        public string LogDate { get; set; }

        public ActivityType ActivityType { get; set; }

        //[DataType(DataType.Currency)]
        public string Income { get; set; }

        //[DataType(DataType.Currency)]
        public string Expense { get; set; }

        public string PlanningID { get; set; }

        public string USRBookCategoryID { get; set; }
    }
}