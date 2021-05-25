using AutoBiller.Data;
using AutoBiller.Models.ServiceEstimate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBiller.Services
{
    public class ServiceEstimateService
    {
        private readonly Guid _bayId;

        public ServiceEstimateService(Guid bayId)
        {
            _bayId = bayId;
        }

        public bool CreateServiceEstimate(ServiceEstimateCreate model)
        {
            var entity =
                new ServiceEstimate()
                {
                    BayId = _bayId,
                    VehicleId = model.VehicleId,
                    ServicePartCost = model.ServicePartCost,
                    VehicleMake = model.VehicleMake,
                    ServiceNotes = model.ServiceNotes,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.ServiceEstimates.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ServiceEstimateListItem> GetServiceEstimates()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .ServiceEstimates
                        .Where(e => e.BayId == _bayId)
                        .Select(
                            e =>
                                new ServiceEstimateListItem
                                {
                                    ServiceId = e.ServiceId,
                                    VehicleId = e.VehicleId,
                                    VehicleMake = e.VehicleMake,
                                }
                        );
                return query.ToArray();
            }
        }

        public ServiceEstimateDetail GetServiceEstimateById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .ServiceEstimates
                        .Single(e => e.ServiceId == id && e.BayId == _bayId);
                return
                    new ServiceEstimateDetail
                    {
                        ServiceId = entity.ServiceId,
                        VehicleId = entity.VehicleId,
                        ServicePartCost = entity.ServicePartCost,
                        ServiceLaborCost = entity.ServiceLaborCost,
                        ServiceSubtotal = entity.ServiceSubtotal,
                        ServiceTax = entity.ServiceTax,
                        ServiceTotalCost = entity.ServiceTotalCost,
                        ServiceNotes = entity.ServiceNotes,
                    };
            }
        }

        public bool UpdateServiceEstimate(ServiceEstimateEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .ServiceEstimates
                        .Single(e => e.ServiceId == model.ServiceId && e.BayId == _bayId);
                entity.ServiceId = model.ServiceId;
                entity.VehicleId = model.VehicleId;
                entity.ServicePartCost = model.ServicePartCost;
                //entity.ServiceLaborCost = model.SerciceLaborCost;
                entity.ServiceNotes = model.ServiceNotes;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteServiceEstimate(int serviceId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .ServiceEstimates
                        .Single(e => e.ServiceId == serviceId && e.BayId == _bayId);

                ctx.ServiceEstimates.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
