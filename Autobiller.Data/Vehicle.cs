using AutoBiller.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBiller.Data
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }

        [ForeignKey(nameof(Customer))]
        public int? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        //public string CustomerName { get; set; }

        //public CarMakes VehicleList { get; set; }

        [Required]
        public string VehicleMake { get; set; }

        [Required]
        public string VehicleModel { get; set; }

        [Required]
        public string VehicleYear { get; set; }

        [Required]
        public double VehicleMileage { get; set; }

        public Guid VehicleTag { get; set; }

        //public virtual ICollection<RepairShop> CustomerVehicle { get; set; } = new List<RepairShop>();

        //public virtual ICollection<Customer> CustomerOwner { get; set; } = new List<Customer>();
    }
}
