using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBiller.Models.Customer
{
    public class CustomerDetail
    {
        public int CustomerId { get; set; }

        public string CustomerFullName { get; set; }

        public string CustomerFirstName { get; set; }

        public string CustomerLastName { get; set; }

        public string CustomerAddress { get; set; }

        public int CustomerPhoneNumber { get; set; }

    }
}
