using System;
using System.Collections.Generic;
using WeddingManager.Core.Data;
using WeddingManager.Core.Repositories;
using System.Linq;
using DB = WeddingManager.Entities;

namespace WeddingManager.Repositories
{
    public class ServiceDetailRepository : IServiceDetailRepository
    {
        public int CreateServiceDetail(int serviceId, ServiceDetail serviceDetail)
        {
            using (var entity = new DB.WeddingManagerEntities())
            {
                var dbService = DbHelpers.GetService(entity, serviceId);

                var dbServiceDetail = new DB.ServiceDetail
                {
                    Service = dbService,
                    Details = serviceDetail.Details,
                    Location = serviceDetail.Location,
                    StartTime = serviceDetail.StartTime,
                    EndTime = serviceDetail.EndTime
                };

                entity.ServiceDetails.Add(dbServiceDetail);

                entity.SaveChanges();

                return dbServiceDetail.Id;
            }
        }

        public IEnumerable<ServiceDetail> RetrieveServiceDetails(int serviceId)
        {
            var output = new List<ServiceDetail>();

            using (var entity = new DB.WeddingManagerEntities())
            {
                var dbServiceDetails = entity.ServiceDetails.Where(sd => sd.DateSuppressed == null &&
                                                                         sd.ServiceId == serviceId &&
                                                                         sd.Service.DateSuppressed == null &&
                                                                         sd.Service.Customer.DateSuppressed == null &&
                                                                         sd.Service.Customer.Company.DateSuppressed == null);

                foreach(var dbServiceDetail in dbServiceDetails)
                {
                    output.Add(new ServiceDetail(dbServiceDetail.Id, dbServiceDetail.Details, dbServiceDetail.Location, dbServiceDetail.StartTime, dbServiceDetail.EndTime));
                }
            }

            return output;
        }

        public void UpdateServiceDetail(ServiceDetail serviceDetail)
        {
            using (var entity = new DB.WeddingManagerEntities())
            {
                var dbServiceDetail = DbHelpers.GetServiceDetail(entity, serviceDetail.Id);

                if (dbServiceDetail != null)
                {
                    dbServiceDetail.Details = serviceDetail.Details;

                    dbServiceDetail.EndTime = serviceDetail.EndTime;

                    dbServiceDetail.Location = serviceDetail.Location;

                    dbServiceDetail.StartTime = serviceDetail.StartTime;

                    entity.SaveChanges();
                }
            }
        }

        public void DeleteServiceDetail(int serviceDetailId)
        {
            using (var entity = new DB.WeddingManagerEntities())
            {
                var dbServiceDetail = DbHelpers.GetServiceDetail(entity, serviceDetailId);

                if(dbServiceDetail != null)
                {
                    dbServiceDetail.DateSuppressed = DateTime.Now;

                    entity.SaveChanges();
                }
            }
        }
    }
}