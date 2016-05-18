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

        public Service RetrieveService(int companyId, int serviceId)
        {
            Service output = null;

            using (var entity = new DB.WeddingManagerEntities())
            {
                var dbService = DbHelpers.GetServices(entity)
                                         .SingleOrDefault(s => s.Customer.CompanyId == companyId && s.Id == serviceId);

                if(dbService != null)
                {
                    output = new Service(dbService.Id, dbService.Description);
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

        public IEnumerable<Service> Search(int companyId, ServiceSearchCriteria searchCriteria)
        {
            var output = new List<Service>();

            using (var entity = new DB.WeddingManagerEntities())
            {
                var dbServices = DbHelpers.GetServices(entity)
                                          .Where(s => s.Customer.CompanyId == companyId);

                if(searchCriteria.StartDate.HasValue)
                {
                    if(searchCriteria.EndDate.HasValue)
                    {
                        dbServices = dbServices.Where(s => s.ServiceDetails.Any(sd => sd.StartTime >= searchCriteria.StartDate.Value && sd.EndTime <= searchCriteria.EndDate.Value));
                    }
                    else
                    {
                        dbServices = dbServices.Where(s => s.ServiceDetails.Any(sd => sd.StartTime >= searchCriteria.StartDate.Value));
                    }
                }
                else if (searchCriteria.EndDate.HasValue)
                {
                    dbServices = dbServices.Where(s => s.ServiceDetails.Any(sd => sd.EndTime <= searchCriteria.EndDate.Value));
                }

                foreach (var dbService in dbServices)
                {
                    output.Add(new Service(dbService.Id, dbService.Description));
                }
            }

            return output;
        }
    }
}