using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autobiller.Data
{
    public class RepairShop
    {
        [Key]
        public int RepairShopId { get; set; }

        [ForeignKey(nameof(Customer))]
        public int? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        [ForeignKey(nameof(Vehicle))]
        public int? VehicleId { get; set; }

        public virtual Vehicle Vehicle { get; set; }

        [ForeignKey(nameof(ServiceEstimate))]
        public int? ServiceId { get; set; }

        public virtual ServiceEstimate ServiceEstimate { get; set; }

    }
}
