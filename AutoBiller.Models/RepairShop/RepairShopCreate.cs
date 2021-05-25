using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBiller.Models.RepairShop
{
    public class RepairShopCreate
    {
        //[Display(Name = "Ticket ID")]
        //public int RepairShopId { get; set; }

        [Display(Name = "Customer ID" )]
        public int? CustomerId { get; set; }

        [Display(Name = "First Name" )]
        public string CustomerFirstName { get; set; }

        [Display(Name = "Last Name" )]
        public string CustomerLastName { get; set; }

        [Display(Name = "Full Name" )]
        public string CustomerFullName
        {
            get { return CustomerFirstName + " " + CustomerLastName; }
        }

        [Display(Name = "Vehicle ID")]
        public int? VehicleId { get; set; }

        [Display(Name = "Vehicle Make" )]
        public string VehicleMake { get; set; }

        [Display(Name = "Vehicle Model" )]
        public string VehicleModel { get; set; }

        [Display(Name = "Service ID" )]
        public int? ServiceId { get; set; }

        [Display(Name = "Total Cost")]
        public double ServiceTotalCost { get; set; }

    }
}
