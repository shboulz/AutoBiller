using AutoBiller.Models.Customer;
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
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var _customerId = Guid.Parse(User.Identity.GetUserId());
            var service = new CustomerService(_customerId);
            var model = service.GetCustomers();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerCreate customer)
        {
            if (!ModelState.IsValid) return View(customer);

            var service = CreateCustomerService();

            if (service.CreateCustomer(customer))
            {
                TempData["SaveResult"] = "Customer profile created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Customer profile could not be created.");

            return View(customer);
        }

        private CustomerService CreateCustomerService()
        {
            var _customerId = Guid.Parse(User.Identity.GetUserId());
            var service = new CustomerService(_customerId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateCustomerService();
            var model = svc.GetCustomerById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateCustomerService();
            var detail = service.GetCustomerById(id);
            var model =
                new CustomerEdit
                {
                    CustomerId = detail.CustomerId,
                    CustomerFirstName = detail.CustomerFirstName,
                    CustomerLastName = detail.CustomerLastName,
                    CustomerAddress = detail.CustomerAddress,
                    CustomerPhoneNumber = detail.CustomerPhoneNumber,
                    IsCustomerVIP = detail.IsCustomerVIP

                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomerEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CustomerId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateCustomerService();

            if (service.UpdateCustomer(model))
            {
                TempData["SaveResult"] = "Customer profile was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Customer profile could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCustomerService();
            var model = svc.GetCustomerById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCustomerService();

            service.DeleteCustomer(id);

            TempData["SaveResult"] = "Customer profile was deleted";

            return RedirectToAction("Index");
        }

    }
}