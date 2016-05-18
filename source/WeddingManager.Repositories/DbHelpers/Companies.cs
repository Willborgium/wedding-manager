using System.Linq;
using WeddingManager.Core.Data;
using DB = WeddingManager.Entities;

namespace WeddingManager.Repositories.DbHelpers
{
    internal static class Companies
    {
        public static DB.Company GetCompany(DB.WeddingManagerEntities entity, int id)
        {
            return entity.Companies.FirstOrDefault(c => c.Id == id && c.DateSuppressed == null);
        }

        public static Company FromDb(DB.Company dbCompany)
        {
            return new Company(dbCompany.Id, dbCompany.Name);
        }
    }
}