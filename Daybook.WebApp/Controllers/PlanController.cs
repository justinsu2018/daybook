using Daybook.Core.Models;
using Daybook.WebApp.Core;
using Daybook.WebApp.Core.ViewModels;
using Daybook.WebApp.Persistence;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;

namespace Daybook.WebApp.Controllers
{
    [Authorize]
    public class PlanController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PlanController()
        {
            _unitOfWork = new UnitOfWork(new DaybookDbContext());
        }

        // GET: Plan
        public ActionResult List()
        {
            var viewModel = new PlansViewModel()
            {
                Plannings = _unitOfWork.PlanRepository
                .GetPlannings(User.Identity.GetUserId())
            };

            return View(viewModel);
        }

        public ActionResult AddPlan()
        {
            var viewModel = new PlanFormViewModel
            {
                Currencies = _unitOfWork.MemberRepository.GetCurrencies()
            };

            ViewBag.Title = "Add Plan";

            return View("PlanForm", viewModel);
        }

        public ActionResult ViewPlan(string planid)
        {
            var p = _unitOfWork.PlanRepository.GetPlanByPlanID(KeyGenerator.Decode(planid));

            if (p.UserID != User.Identity.GetUserId())
            {
                return new HttpUnauthorizedResult();
            }

            var viewModel = new PlanFormViewModel
            {
                PlanningID = planid,
                PlanKind = p.PlanKind,
                PlanningName = p.PlanningName,
                DueDate = p.DueDate,
                RecentBalance = p.RecentBalance,
                CurrencyID = p.CurrencyID,
                Currencies = _unitOfWork.MemberRepository.GetCurrencies(),
            };

            if (string.IsNullOrEmpty(planid))
            {
                viewModel = new PlanFormViewModel();
            }

            ViewBag.Title = "Plan Detail";

            return View("PlanForm", viewModel);
        }

        private void AddOrUpdatePlanRecord(PlanFormViewModel viewModel)
        {
            var actionMode = string.IsNullOrEmpty(viewModel.PlanningID) ? "A" : "U";
            Planning plan = new Planning();

            if (string.IsNullOrEmpty(viewModel.PlanningID))
            {
                //Add
                plan.PlanningID = KeyGenerator.GetUniqKey(User.Identity.GetUserId());
                plan.CreatedBy = User.Identity.GetUserId();
            }
            else
            {
                //Update & Delete
                plan.PlanningID = KeyGenerator.Decode(viewModel.PlanningID);
            }

            plan.PlanKind = viewModel.PlanKind;
            plan.CurrencyID = viewModel.CurrencyID;
            plan.RecentBalance = viewModel.RecentBalance;
            plan.DueDate = viewModel.DueDate;
            plan.PlanningName = viewModel.PlanningName;
            plan.UserID = User.Identity.GetUserId();

            switch (actionMode)
            {
                case "A":
                    plan.CreatedDate = DateTime.UtcNow;

                    _unitOfWork.PlanRepository.AddPlan(plan);
                    break;
                case "U":
                    plan.UpdatedBy = User.Identity.GetUserId();
                    plan.UpdatedDate = DateTime.UtcNow;

                    _unitOfWork.PlanRepository.UpdatePlan(plan);
                    break;
                default:
                    break;
            }


            _unitOfWork.Complete();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ViewPlan(PlanFormViewModel viewModel, string NewPlan, string UpdatePlan, string DeletePlan, string ReturnList)
        {
            if (!string.IsNullOrEmpty(ReturnList))
            {
                return RedirectToAction("List", "Plan");
            }

            if (!string.IsNullOrEmpty(NewPlan))
            {
                if (!ModelState.IsValid)
                {
                    viewModel.Currencies = _unitOfWork.MemberRepository.GetCurrencies();

                    ViewBag.Title = "Add Plan";

                    return View("PlanForm", viewModel);
                }

                AddOrUpdatePlanRecord(viewModel);
            }

            if (!string.IsNullOrEmpty(UpdatePlan))
            {
                if (String.IsNullOrEmpty(viewModel.PlanningID))
                {
                    ModelState.AddModelError("PlanningID", "PlanningID is mandatory");
                }

                var p = _unitOfWork.PlanRepository.GetPlanByPlanID(KeyGenerator.Decode(viewModel.PlanningID));
                if (p == null)
                {
                    ModelState.AddModelError("PlanningID", "No reocrd to update.");
                }

                if (!ModelState.IsValid)
                {
                    viewModel.Currencies = _unitOfWork.MemberRepository.GetCurrencies();

                    ViewBag.Title = "Plan Profile";

                    return View("PlanForm", viewModel);
                }

                AddOrUpdatePlanRecord(viewModel);
            }

            if (!string.IsNullOrEmpty(DeletePlan))
            {
                if (!string.IsNullOrEmpty(viewModel.PlanningID))
                {
                    _unitOfWork.PlanRepository.DeletePlan(KeyGenerator.Decode(viewModel.PlanningID));

                    _unitOfWork.Complete();
                }
            }

            return RedirectToAction("List", "Plan");
        }
    }
}