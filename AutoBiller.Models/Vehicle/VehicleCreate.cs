using AutoBiller.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBiller.Models.Vehicle
{
    public class VehicleCreate
    {
        
        //[Required(ErrorMessage = "Please enter Customer ID")]
        //[Display(Name = "Customer ID")]
        //public int? CustomerId { get; set; }

        [Required(ErrorMessage = "Please enter Vehicle Make")]
        [Display(Name = "Vehicle Make")]
        public string VehicleMake { get; set; }

        [Required(ErrorMessage = "Please enter Vehicle Model")]
        [Display(Name = "Vehicle Model")]
        public string VehicleModel { get; set; }
        //        {
        //            get
        //            {

        //                switch (CarMakes)
        //                {
        //                    case CarMakes.Audi:
        //                        return Enum.GetValues(typeof(AudiModels)).ToString();
        //                    case CarMakes.BMW:
        //                        return Enum.GetValues(typeof(BMWModels)).ToString();
        //                    case CarMakes.Chevrolet:
        //                        return Enum.GetValues(typeof(ChevroletModel)).ToString();
        //                    case CarMakes.Dodge:
        //                        return Enum.GetValues(typeof(DodgeModels)).ToString();
        //                    case CarMakes.Ford:
        //                        return Enum.GetValues(typeof(FordModels)).ToString();
        //                    case CarMakes.Honda:
        //                        return Enum.GetValues(typeof(HondaModels)).ToString();
        //                    case CarMakes.Hyundai:
        //                        return Enum.GetValues(typeof(HyundaiModels)).ToString();
        //                    case CarMakes.Kia:
        //                        return Enum.GetValues(typeof(KiaModels)).ToString();
        //                    case CarMakes.Lexus:
        //                        return Enum.GetValues(typeof(LexusModels)).ToString();
        //                    case CarMakes.Mazda:
        //                        return Enum.GetValues(typeof(MazdaModels)).ToString();
        //                    case CarMakes.Mercedes:
        //                        return Enum.GetValues(typeof(MercedesModels)).ToString();
        //                    case CarMakes.Mitsubishi:
        //                        return Enum.GetValues(typeof(MitsubishiModels)).ToString();
        //                    case CarMakes.Nissan:
        //                        return Enum.GetValues(typeof(NissanModels)).ToString();
        //                    case CarMakes.Subaru:
        //                        return Enum.GetValues(typeof(SubaruModels)).ToString();
        //                    case CarMakes.Toyota:
        //                        return Enum.GetValues(typeof(ToyotaModels)).ToString();
        //                    case CarMakes.Volkswagen:
        //                        return Enum.GetValues(typeof(VolkswagenModels)).ToString();
        //                    default:
        //                        return null;
        //                }

        //}


        [Required(ErrorMessage = "Please enter Vehicle Year Only Ex - 1999")]
        [Display(Name = "Vehicle Year / ****")]
        public string VehicleYear { get; set; }

        [Required(ErrorMessage = "Please enter Vehicle Mileage")]
        [Display(Name = "Vehicle Mileage")]
        public double VehicleMileage { get; set; }

        public int CustomerId { get; set; }

    }
}

