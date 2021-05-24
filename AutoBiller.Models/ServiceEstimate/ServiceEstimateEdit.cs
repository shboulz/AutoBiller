using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBiller.Models.ServiceEstimate
{
    public class ServiceEstimateEdit
    {
        public int ServiceId { get; set; }

        public int? VehicleId { get; set; }

        public double ServicePartCost { get; set; }

        //public double SerciceLaborCost { get; set; }

        public string ServiceNotes { get; set; }
    }
}
