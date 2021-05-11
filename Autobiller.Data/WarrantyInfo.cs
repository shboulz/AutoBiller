using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autobiller.Data
{
    public class WarrantyInfo
    {
        [Key]
        public int WarrantyId { get; set; }

        [Required]
        public bool WarrantyValidation { get; set; }

        [ForeignKey(nameof(Vehicle))]
        public int? VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }


    }
}
