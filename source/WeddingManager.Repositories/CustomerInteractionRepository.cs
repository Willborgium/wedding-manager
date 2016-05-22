using System;
using System.Collections.Generic;
using System.Linq;
using WeddingManager.Core.Data;
using WeddingManager.Core.Repositories;
using DB = WeddingManager.Entities;

namespace WeddingManager.Repositories
{
    public class CustomerInteractionRepository : ICustomerInteractionRepository
    {
        public int CreateCustomerInteraction(int customerId, CustomerInteraction customerInteraction)
        {
            using (var entity = new DB.WeddingManagerEntities())
            {
                var dbCustomer = DbHelpers.Customers.GetCustomer(entity, customerId);

                var dbCustomerInteraction = new DB.CustomerInteraction
                {
                    Customer = dbCustomer,
                    InteractionType = (int)customerInteraction.InteractionType,
                    Date = customerInteraction.Date,
                    Notes = customerInteraction.Notes
                };

                entity.CustomerInteractions.Add(dbCustomerInteraction);

                entity.SaveChanges();

                return dbCustomerInteraction.Id;
            }
        }

        public IEnumerable<CustomerInteraction> RetrieveCustomerInteractions(int customerId)
        {
            var output = new List<CustomerInteraction>();

            using (var entity = new DB.WeddingManagerEntities())
            {
                var dbCustomerInteractions = DbHelpers.CustomerInteractions.GetCustomerInteractions(entity)
                                                                           .Where(ci => ci.CustomerId == customerId);

                foreach(var dbCustomerInteraction in dbCustomerInteractions)
                {
                    output.Add(DbHelpers.CustomerInteractions.FromDb(dbCustomerInteraction));
                }
            }

            return output;
        }

        public void UpdateCustomerInteraction(CustomerInteraction customerInteraction)
        {
            using (var entity = new DB.WeddingManagerEntities())
            {
                var dbCustomerInteraction = DbHelpers.CustomerInteractions.GetCustomerInteraction(entity, customerInteraction.Id);

                if(dbCustomerInteraction != null)
                {
                    dbCustomerInteraction.Date = customerInteraction.Date;

                    dbCustomerInteraction.InteractionType = (int)customerInteraction.InteractionType;

                    dbCustomerInteraction.Notes = customerInteraction.Notes;

                    entity.SaveChanges();
                }
            }
        }

        public void DeleteCustomerInteraction(int customerInteractionId)
        {
            using (var entity = new DB.WeddingManagerEntities())
            {
                var dbCustomerInteraction = DbHelpers.CustomerInteractions.GetCustomerInteraction(entity, customerInteractionId);

                if (dbCustomerInteraction != null)
                {
                    dbCustomerInteraction.DateSuppressed = DateTime.Now;

                    entity.SaveChanges();
                }
            }
        }

        public IDictionary<int, string> RetrieveCustomerInteractionTypes()
        {
            var output = new Dictionary<int, string>();

            using (var entity = new DB.WeddingManagerEntities())
            {
                foreach(var dbCustomerInteractionType in entity.CustomerInteractionTypes)
                {
                    output.Add(dbCustomerInteractionType.Id, dbCustomerInteractionType.Description);
                }
            }

            return output;
        }
    }
}