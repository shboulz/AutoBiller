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
            //var _customerId = Guid.Parse(User.Identity.GetUserId());
            //var service = new CustomerService(_customerId);
            //var model = service.GetCustomers();
            return View();
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
    }
}