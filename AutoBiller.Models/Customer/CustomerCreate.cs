using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBiller.Models.Customer
{
    public class CustomerCreate
    {
        [Required(ErrorMessage = "Please enter First Name")]
        [Display(Name = "First Name")]
        public string CustomerFirstName { get; set; }

        [Required(ErrorMessage = "Please enter Last Name")]
        [Display(Name = "Last Name")]
        public string CustomerLastName { get; set; }

        [Required(ErrorMessage = "Please enter Address")]
        [Display(Name = "Home Address")]
        public string CustomerAddress { get; set; }

        [Required(ErrorMessage = "Please enter Phone Number")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string CustomerPhoneNumber { get; set; }

        [Display(Name = "Repair Shop ID")]
        public int? RepairShopId { get; set; }
    }
}
