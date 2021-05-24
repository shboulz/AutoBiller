using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBiller.Models.RepairShop
{
    public class RepairShopEdit
    {
        public int RepairShopId { get; set; }
        public int? CustomerId { get; set; }

        public string CustomerFirstName { get; set; }

        public string CustomerLastName { get; set; }

        public int? VehicleId { get; set; }

        public string VehicleMake { get; set; }

        public string VehicleModel { get; set; }

        public int? ServiceId { get; set; }

        public double ServiceTotalCost { get; set; }
    }
}
