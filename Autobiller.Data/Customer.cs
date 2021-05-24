using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBiller.Data
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

       
        //[ForeignKey(nameof(RepairShop))]
        //public int RepairShopId { get; set; }
        //public virtual RepairShop RepairShop { get; set; }


        [ForeignKey(nameof(ServiceEstimate))]
        public int? ServiceId { get; set; }
        public virtual ServiceEstimate ServiceEstimate{ get; set; }


        [Required]
        [Display(Name = "First Name")]
        public string CustomerFirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string CustomerLastName { get; set; }

        [Display(Name = "Customer Full Name")]
        public string CustomerFullName
        {
            get { return CustomerFirstName + " " + CustomerLastName; }
        }

        [Required]
        public string CustomerAddress { get; set; }

        [Required]
        public string CustomerPhoneNumber { get; set; }

        [Required]
        public Guid CarOwnerId { get; set; }

        [DefaultValue(false)]
        public bool IsCustomerVIP { get; set; }

        //public virtual ICollection<RepairShop> CustomerRepairShop { get; set; } = new List<RepairShop>();

        public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

    }
}
