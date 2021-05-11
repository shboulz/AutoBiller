using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autobiller.Data
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [ForeignKey(nameof(Vehicle))]
        public int? VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string CustomerFirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string CustomerLastName { get; set; }

        //[Display(Name = "Full Name")]
        //public string CustomerFullName { get; set; }

        [Required]
        public string CustomerAddress { get; set; }

        [Required]
        public int CustomerPhoneNumber { get; set; }

        [Required]
        public Guid CarOwnerId { get; set; }

        [Required]
        public bool IsCustomerVIP { get; set; }

        public virtual ICollection<RepairShop> CustomerRepairShopEstimates { get; set; } = new List<RepairShop>();

        public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

    }
}
