using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBiller.Models.Customer
{
    public class CustomerListItem
    {
        public int CustomerId { get; set; }

        [Display(Name = "First Name")]
        public string CustomerFirstName { get; set; }

        [Display(Name = "Last Name")]
        public string CustomerLastName { get; set; }

        [UIHint("VIP")]
        [Display(Name = "VIP Progam")]
        public bool IsCustomerVIP { get; set; }

    }
}
