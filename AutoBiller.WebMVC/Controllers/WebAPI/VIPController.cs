using AutoBiller.Models.Customer;
using AutoBiller.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AutoBiller.WebMVC.Controllers.WebAPI
{
    [Authorize]
    [RoutePrefix("api/Customer")]
    public class VIPController : ApiController
    {
        private bool SetStarState(int customerId, bool newState)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CustomerService(userId);

            var detail = service.GetCustomerById(customerId);

            var updatedCustomer =
                new CustomerEdit
                {
                    CustomerId = detail.CustomerId,
                    CustomerFirstName = detail.CustomerFirstName,
                    CustomerLastName = detail.CustomerLastName,
                    CustomerAddress = detail.CustomerAddress,
                    CustomerPhoneNumber = detail.CustomerPhoneNumber,
                    IsCustomerVIP = newState
                };

            return service.UpdateCustomer(updatedCustomer);
        }

        [Route("{id}/Star")]
        [HttpPut]
        public bool ToggleStarOn(int id) => SetStarState(id, true);

        [Route("{id}/Star")]
        [HttpDelete]
        public bool ToggleStarOff(int id) => SetStarState(id, false);
    }
}
