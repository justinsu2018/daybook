using Daybook.WebApp.Core;
using Daybook.WebApp.Core.ViewModels;
using Daybook.WebApp.Persistence;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace Daybook.WebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController()
        {
            _unitOfWork = new UnitOfWork(new DaybookDbContext());
        }

        public ActionResult Index()
        {
            return RedirectToAction("Dashboard");
        }

        public ActionResult Dashboard()
        {
            ViewBag.Title = "Dashboard";

            var viewModel = new DashboardViewModel()
            {
                Plannings = _unitOfWork.PlanRepository.GetPlannings(User.Identity.GetUserId())
            };

            return View(viewModel);
        }
    }
}