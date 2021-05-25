using AutoBiller.Data;
using AutoBiller.Models.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBiller.Services
{
    public class VehicleService
    {
        private readonly Guid _vehicleTag;

        public VehicleService(Guid vehicleTag)
        {
            _vehicleTag = vehicleTag;
        }
        public bool CreateVehicle(VehicleCreate model)
        {
            var entity =
                new Vehicle()
                {
                    VehicleTag = _vehicleTag,
                    CustomerId=model.CustomerId,
                    VehicleMake = model.VehicleMake,
                    VehicleModel = model.VehicleModel,
                    VehicleYear = model.VehicleYear,
                    VehicleMileage = model.VehicleMileage
                };

            using (var ctx = new ApplicationDbContext())
            {
                var customer = ctx.Customers.SingleOrDefault(c => c.CustomerId == entity.CustomerId);
                customer.Vehicles.Add(entity);
                ctx.Vehicles.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<VehicleListItem> GetVehicles()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Vehicles
                        .Where(e => e.VehicleTag == _vehicleTag)
                        .Select(
                            e =>
                                new VehicleListItem
                                {
                                    VehicleId = e.VehicleId,
                                    VehicleMake = e.VehicleMake,
                                }
                        );

                return query.ToArray();
            }
        }

        public VehicleDetail GetVehicleById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Vehicles
                        .Single(e => e.VehicleId == id && e.VehicleTag == _vehicleTag);
                return
                    new VehicleDetail
                    {
                        VehicleId = entity.VehicleId,
                        VehicleMake = entity.VehicleMake,
                        VehicleModel = entity.VehicleModel,
                        VehicleYear = entity.VehicleYear,
                        VehicleMileage = entity.VehicleMileage
                    };
            }
        }

        public bool UpdateVehicle(VehicleEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Vehicles
                        .Single(e => e.VehicleId == model.VehicleId && e.VehicleTag == _vehicleTag);

                entity.VehicleId = model.VehicleId;
                entity.VehicleMake = model.VehicleMake;
                entity.VehicleModel = model.VehicleModel;
                entity.VehicleYear = model.VehicleYear;
                entity.VehicleMileage = model.VehicleMileage;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteVehicle(int vehicleId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Vehicles
                        .Single(e => e.VehicleId == vehicleId && e.VehicleTag == _vehicleTag);

                ctx.Vehicles.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
