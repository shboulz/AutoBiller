using Autobiller.Data;
using AutoBiller.Data;
using AutoBiller.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBiller.Services
{
    public class CustomerService
    {
        private readonly Guid _customerId;

        public CustomerService(Guid customerId)
        {
            _customerId = customerId;
        }

        public bool CreateCustomer(CustomerCreate model)
        {
            var entity =
                new Customer()
                {
                    CarOwnerId = _customerId,
                    CustomerFirstName = model.CustomerFirstName,
                    CustomerLastName = model.CustomerLastName,
                    CustomerAddress = model.CustomerAddress,
                    CustomerPhoneNumber = model.CustomerPhoneNumber
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Customers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
