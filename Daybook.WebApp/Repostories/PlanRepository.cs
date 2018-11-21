using Daybook.Core.Models;
using Daybook.WebApp.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace Daybook.WebApp.Repostories
{
    public class PlanRepository : IPlanRepository
    {
        private readonly DaybookDbContext _context;

        public PlanRepository(DaybookDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Planning> GetPlannings(string userid)
        {
            return _context.Plannings
                .Where(p => p.UserID == userid)
                .ToList();
        }

        public Planning GetPlanByPlanID(string planid)
        {
            var plan = _context.Plannings
                .SingleOrDefault(p => p.PlanningID == planid);

            if (plan == null)
                throw new KeyNotFoundException();

            return plan;
        }

        public void AddPlan(Planning plan)
        {
            _context.Plannings.Add(plan);
        }

        public void UpdatePlan(Planning plan)
        {
            var orgPlan = _context.Plannings
                .SingleOrDefault(p => p.PlanningID == plan.PlanningID);

            if (orgPlan == null)
                throw new KeyNotFoundException();

            orgPlan.PlanKind = plan.PlanKind;
            orgPlan.PlanningName = plan.PlanningName;
            orgPlan.DueDate = plan.DueDate;
            orgPlan.CurrencyID = plan.CurrencyID;
            orgPlan.UpdatedDate = plan.UpdatedDate;
            orgPlan.UpdatedBy = plan.UpdatedBy;
        }

        public void DeletePlan(string planid)
        {
            var op = _context.Plannings.SingleOrDefault(p => p.PlanningID == planid);
            if (op == null)
                throw new KeyNotFoundException();

            _context.Plannings.Remove(op);
        }
    }
}