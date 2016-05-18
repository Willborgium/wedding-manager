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
                var dbService = DbHelpers.Services.GetService(entity, serviceId);

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
                    output.Add(DbHelpers.ServiceDetails.FromDb(dbServiceDetail));
                }
            }

            return output;
        }

        public void UpdateServiceDetail(ServiceDetail serviceDetail)
        {
            using (var entity = new DB.WeddingManagerEntities())
            {
                var dbServiceDetail = DbHelpers.ServiceDetails.GetServiceDetail(entity, serviceDetail.Id);

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
                var dbServiceDetail = DbHelpers.ServiceDetails.GetServiceDetail(entity, serviceDetailId);

                if(dbServiceDetail != null)
                {
                    dbServiceDetail.DateSuppressed = DateTime.Now;

                    entity.SaveChanges();
                }
            }
        }

        public IEnumerable<ServiceDetailSearchResult> Search(int companyId, ServiceDetailSearchCriteria searchCriteria)
        {
            var output = new List<ServiceDetailSearchResult>();

            using (var entity = new DB.WeddingManagerEntities())
            {
                var dbServiceDetails = DbHelpers.Services.GetServices(entity)
                                                .Where(s => s.Customer.CompanyId == companyId)
                                                .SelectMany(s => s.ServiceDetails);

                if (searchCriteria.StartDate.HasValue)
                {
                    dbServiceDetails = dbServiceDetails.Where(sd => sd.StartTime >= searchCriteria.StartDate.Value);
                }

                if (searchCriteria.EndDate.HasValue)
                {
                    dbServiceDetails = dbServiceDetails.Where(sd => sd.EndTime <= searchCriteria.EndDate.Value);
                }

                foreach (var dbServiceDetail in dbServiceDetails)
                {
                    output.Add(DbHelpers.ServiceDetails.ToSearchResult(dbServiceDetail));
                }
            }

            return output;
        }
    }
}