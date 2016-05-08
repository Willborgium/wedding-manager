using System;
using System.Collections.Generic;
using System.Linq;
using WeddingManager.Core.Data;
using WeddingManager.Core.Repositories;
using DB = WeddingManager.Entities;

namespace WeddingManager.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        public int CreateService(int customerId, Service service)
        {
            using (var entity = new DB.WeddingManagerEntities())
            {
                var dbCustomer = DbHelpers.GetCustomer(entity, customerId);

                var dbService = new DB.Service
                {
                    Customer = dbCustomer,
                    Description = service.Description
                };

                entity.Services.Add(dbService);

                entity.SaveChanges();

                return dbService.Id;
            }
        }

        public IEnumerable<Service> RetrieveServices(int customerId)
        {
            var output = new List<Service>();

            using (var entity = new DB.WeddingManagerEntities())
            {
                var dbServices = entity.Services.Where(s => s.CustomerId == customerId &&
                                                            s.DateSuppressed == null &&
                                                            s.Customer.DateSuppressed == null &&
                                                            s.Customer.Company.DateSuppressed == null);

                foreach (var dbService in dbServices)
                {
                    output.Add(new Service(dbService.Id, dbService.Description));
                }
            }

            return output;
        }

        public void UpdateService(Service service)
        {
            using (var entity = new DB.WeddingManagerEntities())
            {
                var dbService = DbHelpers.GetService(entity, service.Id);

                if (dbService != null)
                {
                    dbService.Description = service.Description;

                    entity.SaveChanges();
                }
            }
        }

        public void DeleteService(int serviceId)
        {
            using (var entity = new DB.WeddingManagerEntities())
            {
                var dbService = DbHelpers.GetService(entity, serviceId);

                if (dbService != null)
                {
                    dbService.DateSuppressed = DateTime.Now;

                    entity.SaveChanges();
                }
            }
        }
    }
}