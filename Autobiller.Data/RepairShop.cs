using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBiller.Data
{
    public class RepairShop
    {
        [Key]
        [Display(Name = "Ticket Number")]
        public int RepairShopId { get; set; }

        [ForeignKey(nameof(Customer))]
        [Display(Name = "Customer ID")]
        public int? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [Display(Name = "First Name")]
        public string CustomerFirstName { get; set; }

        [Display(Name = "Last Name")]
        public string CustomerLastName { get; set; }

        [Display(Name = "Full Name")]
        public string CustomerFullName
        {
            get { return CustomerFirstName + " " + CustomerLastName; }
        }

        [ForeignKey(nameof(Vehicle))]
        [Display(Name = "Vehicle ID")]
        public int? VehicleId { get; set; }

        public virtual Vehicle Vehicle { get; set; }
        public string VehicleMake { get; set; }

        public string VehicleModel { get; set; }

        [ForeignKey(nameof(ServiceEstimate))]
        [Display(Name = "Service ID")]
        public int? ServiceId { get; set; }

        public virtual ServiceEstimate ServiceEstimate { get; set; }

        [Display(Name = "Service Total")]
        public double ServiceTotalCost { get; set; }

        public ICollection<Customer> RecentCustomers { get; set; } = new List<Customer>();
        public ICollection<Vehicle> RecentVehicles { get; set; } = new List<Vehicle>();
        public ICollection<ServiceEstimate> RecentTickets { get; set; } = new List<ServiceEstimate>();
    }
}
