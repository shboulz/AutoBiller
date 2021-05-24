using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBiller.Models.Vehicle
{
    public class VehicleEdit
    {
        public int VehicleId { get; set; }

        public string VehicleMake { get; set; }

        public string VehicleModel { get; set; }

        public string VehicleYear { get; set; }

        public double VehicleMileage { get; set; }
    }
}
