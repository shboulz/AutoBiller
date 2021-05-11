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

        public string CustomerFullName { get; set; }

        [UIHint("VIP")]
        [Display(Name = "VIP Progam")]
        public bool IsCustomerVIP { get; set; }

    }
}
