using System.Linq;
using WeddingManager.Core.Data;
using DB = WeddingManager.Entities;

namespace WeddingManager.Repositories.DbHelpers
{
    internal static class CustomerInteractions
    {
        internal static IQueryable<DB.CustomerInteraction> GetCustomerInteractions(DB.WeddingManagerEntities entity)
        {
            return entity.CustomerInteractions.Where(ci => ci.DateSuppressed == null &&
                                                           ci.Customer.DateSuppressed == null &&
                                                           ci.Customer.Company.DateSuppressed == null);
        }

        internal static DB.CustomerInteraction GetCustomerInteraction(DB.WeddingManagerEntities entity, int customerInteractionId)
        {
            return GetCustomerInteractions(entity).FirstOrDefault(ci => ci.Id == customerInteractionId);
        }

        internal static CustomerInteraction FromDb(DB.CustomerInteraction dbCustomerInteraction)
        {
            return new CustomerInteraction(dbCustomerInteraction.Id, (CustomerInteractionType)dbCustomerInteraction.InteractionType, dbCustomerInteraction.Date, dbCustomerInteraction.Notes);
        }
    }
}