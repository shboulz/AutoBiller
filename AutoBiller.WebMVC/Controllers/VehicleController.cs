using AutoBiller.Models.Vehicle;
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
    public class VehicleController : Controller
    {
        // GET: Vehicle
        public ActionResult Index()
        {
            var _vehicleTag = Guid.Parse(User.Identity.GetUserId());
            var service = new VehicleService(_vehicleTag);
            var model = service.GetVehicles();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehicleCreate vehicle)
        {
            if (!ModelState.IsValid) return View(vehicle);

            var service = CreateVehicleService();

            if (service.CreateVehicle(vehicle))
            {
                TempData["SaveResult"] = "Vehicle added to profile created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Vehicle could not be created");

            return View(vehicle);
        }

        private VehicleService CreateVehicleService()
        {
            var _vehicleTag = Guid.Parse(User.Identity.GetUserId());
            var service = new VehicleService(_vehicleTag);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateVehicleService();
            var model = svc.GetVehicleById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateVehicleService();
            var detail = service.GetVehicleById(id);
            var model =
                new VehicleEdit
                {
                   VehicleId = detail.VehicleId,
                   VehicleMake = detail.VehicleMake,
                   VehicleModel = detail.VehicleModel,
                   VehicleYear = detail.VehicleYear,
                   VehicleMileage = detail.VehicleMileage
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VehicleEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.VehicleId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateVehicleService();

            if (service.UpdateVehicle(model))
            {
                TempData["SaveResult"] = "Vehicle profile was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Vehicle profile could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateVehicleService();
            var model = svc.GetVehicleById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateVehicleService();

            service.DeleteVehicle(id);

            TempData["SaveResult"] = "Vehicle profile was deleted";

            return RedirectToAction("Index");
        }
    }
}