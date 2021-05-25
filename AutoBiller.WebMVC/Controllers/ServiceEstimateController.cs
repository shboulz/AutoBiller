using AutoBiller.Models.ServiceEstimate;
using AutoBiller.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoBiller.WebMVC.Controllers
{
    [Authorize]
    public class ServiceEstimateController : Controller
    {
        // GET: ServiceEstimate
        public ActionResult Index()
        {
            var _bayId = Guid.Parse(User.Identity.GetUserId());
            var service = new ServiceEstimateService(_bayId);
            var model = service.GetServiceEstimates();
            return View(model); 
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServiceEstimateCreate serviceEstimate)
        {
            if (!ModelState.IsValid) return View(serviceEstimate);

            var service = CreateServiceEstimateService();

            if (service.CreateServiceEstimate(serviceEstimate))
            {
                TempData["SaveResult"] = "Estimate added to profile created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Estimate could not be created");

            return View(serviceEstimate);
        }

        private ServiceEstimateService CreateServiceEstimateService()
        {
            var _bayId = Guid.Parse(User.Identity.GetUserId());
            var service = new ServiceEstimateService(_bayId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateServiceEstimateService();
            var model = svc.GetServiceEstimateById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateServiceEstimateService();
            var detail = service.GetServiceEstimateById(id);
            var model =
                new ServiceEstimateEdit
                {
                    ServiceId = detail.ServiceId,
                    VehicleId = detail.VehicleId,
                    ServicePartCost = detail.ServicePartCost,
                    ServiceNotes = detail.ServiceNotes
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ServiceEstimateEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.VehicleId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateServiceEstimateService();

            if (service.UpdateServiceEstimate(model))
            {
                TempData["SaveResult"] = "Estimate profile was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Estimate profile could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateServiceEstimateService();
            var model = svc.GetServiceEstimateById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateServiceEstimateService();

            service.DeleteServiceEstimate(id);

            TempData["SaveResult"] = "Estimate profile was deleted";

            return RedirectToAction("Index");
        }
    }


}