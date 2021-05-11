using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autobiller.Data
{
    public class ServiceEstimate
    {
        [Key]
        public int ServiceId { get; set; }

        [ForeignKey(nameof(WarrantyInfo))]
        public int? WarrantyId { get; set; }
        public virtual WarrantyInfo WarrantyInfo { get; set; }

        [Required]
        public double ServiceTax { get; set; }

        [Required]
        public double ServiceLaborCost { get; set; }

        [Required]
        public double ServicePartCost { get; set; }

        [Required]
        public bool ServiceDiscountVIP { get; set; }

        [Required]
        public double DiscountVIP { get; set; }

        [Required]
        public bool IsVehicleWarrantyValid { get; set; }

        [Required]
        public double ServiceTotalCost { get; set; }

    }
}
