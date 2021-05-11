using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBiller.Models.Customer
{
    public class CustomerEdit
    {
        [Display(Name = "First Name")]
        public string CustomerFirstName { get; set; }

        [Display(Name = "Last Name")]
        public string CustomerLastName { get; set; }

        [Display(Name = "Home Address")]
        public string CustomerAddress { get; set; }

        [Display(Name = "Phone Number")]
        public int CustomerPhoneNumber { get; set; }

        //[Display(Name = "Vehicle Make")]
        //public string VehicleMake { get; set; }

        //[Display(Name = "Vehicle Model")]
        //public string VehicleModel { get; set; }

        //[Display(Name = "Vehicle Year")]
        //public int VehicleYear { get; set; }

        //[Display(Name = "Vehicle Mileage")]
        //public double VehicleMileage { get; set; }

        [Display(Name = "VIP Program")]
        public bool IsCustomerVIP { get; set; }
    }
}
