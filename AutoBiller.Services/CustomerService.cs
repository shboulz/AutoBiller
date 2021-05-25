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
                    //RepairShopId=model.RepairShopId,
                    CustomerFirstName = model.CustomerFirstName,
                    CustomerLastName = model.CustomerLastName,
                    CustomerAddress = model.CustomerAddress,
                    CustomerPhoneNumber = model.CustomerPhoneNumber
                };

            using (var ctx = new ApplicationDbContext())
            {
                //var ticket = ctx.RepairShops.SingleOrDefault(c => c.RepairShopId == entity.RepairShopId);
                //ticket.RecentCustomers.Add(entity);
                ctx.Customers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CustomerListItem> GetCustomers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Customers
                        .Where(e => e.CarOwnerId == _customerId)
                        .Select(
                            e =>
                                new CustomerListItem
                                {
                                    CustomerId = e.CustomerId,
                                    CustomerFirstName = e.CustomerFirstName,
                                    CustomerLastName = e.CustomerLastName,
                                    IsCustomerVIP = e.IsCustomerVIP
                                }
                        );

                return query.ToArray();
            }
        }

        public CustomerDetail GetCustomerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerId == id && e.CarOwnerId == _customerId);
                return
                    new CustomerDetail
                    {
                        CustomerId = entity.CustomerId,
                        CustomerFirstName = entity.CustomerFirstName,
                        CustomerLastName = entity.CustomerLastName,
                        CustomerAddress = entity.CustomerAddress,
                        CustomerPhoneNumber = entity.CustomerPhoneNumber,
                        IsCustomerVIP = entity.IsCustomerVIP
                        //grab the list of vehicles
                    };
            }
        }

        public bool UpdateCustomer(CustomerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerId == model.CustomerId && e.CarOwnerId == _customerId);

                entity.CustomerFirstName = model.CustomerFirstName;
                entity.CustomerLastName = model.CustomerLastName;
                entity.CustomerAddress = model.CustomerAddress;
                entity.CustomerPhoneNumber = model.CustomerPhoneNumber;
                entity.IsCustomerVIP = model.IsCustomerVIP;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCustomer(int customerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerId == customerId && e.CarOwnerId == _customerId);

                ctx.Customers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
