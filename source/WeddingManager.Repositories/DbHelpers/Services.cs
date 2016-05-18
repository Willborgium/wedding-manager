using System.Linq;
using WeddingManager.Core.Data;
using DB = WeddingManager.Entities;

namespace WeddingManager.Repositories.DbHelpers
{
    internal static class Services
    {
        internal static IQueryable<DB.Service> GetServices(DB.WeddingManagerEntities entity)
        {
            return entity.Services.Where(s => s.DateSuppressed == null &&
                                              s.Customer.DateSuppressed == null &&
                                              s.Customer.Company.DateSuppressed == null);
        }

        internal static DB.Service GetService(DB.WeddingManagerEntities entity, int id)
        {
            return GetServices(entity).FirstOrDefault(s => s.Id == id);
        }

        internal static Service FromDb(DB.Service dbService)
        {
            return new Service(dbService.Id, dbService.Description);
        }
    }
}