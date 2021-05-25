using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBiller.Models.ServiceEstimate
{
    public class ServiceEstimateDetail
    {
        public int ServiceId { get; set; }

        public int? VehicleId { get; set; }

        public double ServicePartCost { get; set; }

        public double ServiceLaborCost { get; set; }

        public double ServiceSubtotal { get; set; }

        public double ServiceTax { get; set; }

        public double ServiceTotalCost { get; set; }

        public string ServiceNotes { get; set; }
    }
}
