using System.Linq;
using WeddingManager.Core.Data;
using DB = WeddingManager.Entities;

namespace WeddingManager.Repositories.DbHelpers
{
    internal static class Customers
    {
        internal static DB.Customer GetCustomer(DB.WeddingManagerEntities entity, int id)
        {
            return entity.Customers.FirstOrDefault(c => c.Id == id &&
                                                        c.DateSuppressed == null &&
                                                        c.Company.DateSuppressed == null);
        }

        internal static Customer FromDb(DB.Customer dbCustomer)
        {
            return new Customer(dbCustomer.Id, dbCustomer.FirstName, dbCustomer.LastName, dbCustomer.PhoneNumber, dbCustomer.Notes);
        }
    }
}