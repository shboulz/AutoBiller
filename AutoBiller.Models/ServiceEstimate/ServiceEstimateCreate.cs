using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBiller.Models.ServiceEstimate
{
    public class ServiceEstimateCreate
    {
        public int? VehicleId { get; set; }

        public double ServicePartCost { get; set; }

        public string VehicleMake { get; set; }

        public string ServiceNotes { get; set; }
    }
}
