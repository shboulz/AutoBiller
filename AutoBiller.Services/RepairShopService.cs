using AutoBiller.Data;
using AutoBiller.Models.RepairShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBiller.Services
{
    public class RepairShopService
    {
        public bool CreateRepairShop(RepairShopCreate model)
        {
            var entity =
                new RepairShop()
                {
                    //RepairShopId = model.RepairShopId,
                    CustomerId = model.CustomerId,
                    CustomerFirstName = model.CustomerFirstName,
                    CustomerLastName = model.CustomerLastName,
                    VehicleId = model.VehicleId,
                    VehicleMake = model.VehicleMake,
                    VehicleModel = model.VehicleModel,
                    ServiceId = model.ServiceId,
                    ServiceTotalCost = model.ServiceTotalCost
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.RepairShops.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RepairShopListItem> GetRepairShop(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .RepairShops
                        .Where(e => e.RepairShopId == id)
                        .Select(
                            e =>
                                new RepairShopListItem
                                {
                                    RepairShopId = e.RepairShopId,
                                    CustomerId = e.CustomerId,
                                    CustomerFirstName = e.CustomerFirstName,
                                    CustomerLastName = e.CustomerLastName,
                                    
                                }
                        );

                return query.ToArray();
            }
        }

        public bool UpdateRepairShop(RepairShopEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .RepairShops
                        .Single(e => e.RepairShopId == model.RepairShopId);

                entity.CustomerId = model.CustomerId;
                entity.CustomerFirstName = model.CustomerFirstName;
                entity.CustomerLastName = model.CustomerLastName;
                entity.VehicleId = model.VehicleId;
                entity.VehicleMake = model.VehicleMake;
                entity.VehicleModel = model.VehicleModel;
                entity.ServiceId = model.ServiceId;
                entity.ServiceTotalCost = model.ServiceTotalCost;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRepairShop(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .RepairShops
                        .Single(e => e.RepairShopId == id);

                ctx.RepairShops.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }



        public RepairShopDetail GetRepairShopById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .RepairShops
                        .Single(e => e.RepairShopId == id);
                return
                    new RepairShopDetail
                    {
                        RepairShopId = entity.RepairShopId,
                        CustomerId = entity.CustomerId,
                        CustomerFirstName = entity.CustomerFirstName,
                        CustomerLastName = entity.CustomerLastName,
                        //CustomerFullName = entity.CustomerFullName,
                        VehicleId = entity.VehicleId,
                        VehicleMake = entity.VehicleMake,
                        VehicleModel = entity.VehicleModel,
                        ServiceId = entity.ServiceId,
                        ServiceTotalCost = entity.ServiceTotalCost
                    };
            }
        }
    }
}
