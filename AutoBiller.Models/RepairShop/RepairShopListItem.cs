using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBiller.Models.RepairShop
{
    public class RepairShopListItem
    {
        public int RepairShopId { get; set; }

        public int? CustomerId { get; set; }

        public string CustomerFirstName { get; set; }

        public string CustomerLastName { get; set; }
    }
}
