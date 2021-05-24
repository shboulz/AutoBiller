using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBiller.Models.Customer
{
    public class CustomerDetail
    {
        public int CustomerId { get; set; }

        //[Display(Name = "Full Name")]
        //public string CustomerFullName
        //{
        //    get { return CustomerFirstName + " " + CustomerLastName; }
        //}

        [Display(Name = "First Name")]
        public string CustomerFirstName { get; set; }

        [Display(Name = "Last Name")]
        public string CustomerLastName { get; set; }

        [Display(Name = "Address")]
        public string CustomerAddress { get; set; }

        [Display(Name = "Phone Number")]
        public string CustomerPhoneNumber { get; set; }

        public bool IsCustomerVIP { get; set; }

    }
}
