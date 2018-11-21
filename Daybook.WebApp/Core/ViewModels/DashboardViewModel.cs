using Daybook.Core.Models;
using System.Collections.Generic;

namespace Daybook.WebApp.Core.ViewModels
{
    public class DashboardViewModel
    {
        public IEnumerable<Planning> Plannings { get; set; }
    }
}