using AutoBiller.Data;
using AutoBiller.Models.RepairShop;
using AutoBiller.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoBiller.WebMVC.Controllers
{
    [Authorize]
    public class RepairShopController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        public ActionResult Index()
        {
            List<RepairShop> ticketList = _db.RepairShops.ToList();
            List<RepairShop> orderedList = ticketList.OrderBy(tic => tic.RepairShopId).ToList();
            return View(orderedList);
        }

        // GET: Note/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RepairShopCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateRepairShopService();

            if (service.CreateRepairShop(model))
            {
                TempData["SaveResult"] = "Your ticket was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Ticket could not be created.");

            return View(model);
        }

        private RepairShopService CreateRepairShopService()
        {
            var service = new RepairShopService();
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateRepairShopService();
            var model = svc.GetRepairShopById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateRepairShopService();
            var detail = service.GetRepairShopById(id);
            var model =
                new RepairShopEdit
                {
                    RepairShopId = detail.RepairShopId,
                    CustomerId = detail.CustomerId,
                    CustomerFirstName = detail.CustomerFirstName,
                    CustomerLastName = detail.CustomerLastName,
                    VehicleId = detail.VehicleId,
                    VehicleMake = detail.VehicleMake,
                    VehicleModel = detail.VehicleModel,
                    ServiceId = detail.ServiceId,
                    ServiceTotalCost = detail.ServiceTotalCost
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RepairShopEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.RepairShopId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateRepairShopService();

            if (service.UpdateRepairShop(model))
            {
                TempData["SaveResult"] = "Your ticket was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your ticket could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateRepairShopService();
            var model = svc.GetRepairShopById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateRepairShopService();

            service.DeleteRepairShop(id);

            TempData["SaveResult"] = "Your ticket was deleted";

            return RedirectToAction("Index");
        }
    }
}