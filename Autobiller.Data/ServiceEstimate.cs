using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBiller.Data
{
    public class ServiceEstimate
    {
        [Key]
        public int ServiceId { get; set; }

        [ForeignKey(nameof(RepairShop))]
        public int? RepairShopId { get; set; }
        public virtual RepairShop RepairShop { get; set; }

        public Guid BayId { get; set; }
        [ForeignKey(nameof(Vehicle))]
        public int? VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        public string VehicleMake { get; set; }

        public string ServiceNotes { get; set; }

        public double ServiceTax 
        {
            get
            {
               return 0.07;
            }
        }

        public double ServiceLaborCost 
        {
            get
            {
                return 55.00;
            }

        }

        [Required]
        public double ServicePartCost { get; set; }

        public double ServiceSubtotal 
        {
            get
            {
                return ServicePartCost + ServiceLaborCost;
            }
        }

        public double ServiceTotalCost 
        {
            get
            {
                return (ServiceSubtotal * ServiceTax) + ServiceSubtotal;
            }
        }

        //public virtual ICollection<Vehicle> CustomerVehicles { get; set; } = new List<Vehicle>();

        //public virtual ICollection<RepairShop> CustomerRepairShopEstimates { get; set; } = new List<RepairShop>();
        public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
    }
}
