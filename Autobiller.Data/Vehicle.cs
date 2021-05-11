using Autobiller.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autobiller.Data
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }

        [ForeignKey(nameof(Customer))]
        public int? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        [Required]
        public VehicleEnums VehicleMake { get; set; }

        [Required]
        public string VehicleModel { get; set; }

        [Required]
        public int VehicleYear { get; set; }

        [Required]
        public double VehicleMileage { get; set; }

    }
}
