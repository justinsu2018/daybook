using System.Collections.Generic;
using Daybook.Core.Models;

namespace Daybook.WebApp.Repostories
{
    public interface IPlanRepository
    {
        void AddPlan(Planning plan);
        void DeletePlan(string planid);
        Planning GetPlanByPlanID(string planid);
        IEnumerable<Planning> GetPlannings(string userid);
        void UpdatePlan(Planning plan);
    }
}