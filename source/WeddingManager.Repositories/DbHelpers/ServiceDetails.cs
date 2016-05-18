using System;
using System.Linq;
using WeddingManager.Core.Data;
using DB = WeddingManager.Entities;

namespace WeddingManager.Repositories.DbHelpers
{
    internal static class ServiceDetails
    {
        internal static DB.ServiceDetail GetServiceDetail(DB.WeddingManagerEntities entity, int id)
        {
            return entity.ServiceDetails.FirstOrDefault(sd => sd.Id == id &&
                                                              sd.DateSuppressed == null &&
                                                              sd.Service.DateSuppressed == null &&
                                                              sd.Service.Customer.DateSuppressed == null &&
                                                              sd.Service.Customer.Company.DateSuppressed == null);
        }

        internal static ServiceDetail FromDb(DB.ServiceDetail dbServiceDetail)
        {
            return new ServiceDetail(dbServiceDetail.Id, dbServiceDetail.Details, dbServiceDetail.Location, dbServiceDetail.StartTime, dbServiceDetail.EndTime);
        }

        internal static ServiceDetailSearchResult ToSearchResult(DB.ServiceDetail dbServiceDetail)
        {
            var customer = DbHelpers.Customers.FromDb(dbServiceDetail.Service.Customer);

            var service = DbHelpers.Services.FromDb(dbServiceDetail.Service);

            var serviceDetail = FromDb(dbServiceDetail);

            return new ServiceDetailSearchResult(customer, service, serviceDetail);
        }
    }
}