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
                var dbCustomer = entity.Customers.FirstOrDefault(c => c.Id == customerId &&
                                                                      c.DateSuppressed == null &&
                                                                      c.Company.DateSuppressed == null);

                var dbService = new DB.Service
                {
                    Customer = dbCustomer,
                    Description = service.Description,
                    Location = service.Location,
                    StartTime = service.StartTime,
                    EndTime = service.EndTime
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
                    output.Add(new Service(dbService.Id, dbService.Description, dbService.Location, dbService.StartTime, dbService.EndTime));
                }
            }

            return output;
        }

        public void UpdateService(Service service)
        {
            using (var entity = new DB.WeddingManagerEntities())
            {
                var dbService = entity.Services.FirstOrDefault(s => s.Id == service.Id &&
                                                                    s.DateSuppressed == null &&
                                                                    s.Customer.DateSuppressed == null &&
                                                                    s.Customer.Company.DateSuppressed == null);

                if (dbService != null)
                {
                    dbService.Description = service.Description;

                    dbService.Location = service.Location;

                    dbService.StartTime = service.StartTime;

                    dbService.EndTime = service.EndTime;
                }

                entity.SaveChanges();
            }
        }

        public void DeleteService(int serviceId)
        {
            using (var entity = new DB.WeddingManagerEntities())
            {
                var dbService = entity.Services.FirstOrDefault(s => s.Id == serviceId &&
                                                                    s.DateSuppressed == null &&
                                                                    s.Customer.DateSuppressed == null &&
                                                                    s.Customer.Company.DateSuppressed == null);

                dbService.DateSuppressed = DateTime.Now;

                entity.SaveChanges();
            }
        }
    }
}