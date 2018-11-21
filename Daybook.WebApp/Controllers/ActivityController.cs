using Daybook.WebApp.Core;
using Daybook.WebApp.Core.ViewModels;
using Daybook.WebApp.Persistence;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;

namespace Daybook.WebApp.Controllers
{
    public class ActivityController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActivityController()
        {
            _unitOfWork = new UnitOfWork(new DaybookDbContext());
        }

        // GET: Activity
        public ActionResult NewActivity(string planid)
        {
            var plan = _unitOfWork.PlanRepository.GetPlanByPlanID(KeyGenerator.Decode(planid));
            if (plan == null)
                throw new ArgumentNullException();

            if (plan.UserID != User.Identity.GetUserId())
                throw new UnauthorizedAccessException();

            var viewModel = new ActivityLogFormViewModel()
            {
                PlanningID = planid,
                LogDate = DateTime.Now.ToShortDateString(),
                USRBookCategoryID = plan.CurrencyID
            };

            ViewBag.Title = "New Activity";

            return View(viewModel);
        }
    }
}