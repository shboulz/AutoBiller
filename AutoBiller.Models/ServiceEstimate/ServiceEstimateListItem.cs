using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBiller.Models.ServiceEstimate
{
    public class ServiceEstimateListItem
    {
        public int ServiceId { get; set; }

        public int? VehicleId { get; set; }

        public string VehicleMake { get; set; }
    }
}
