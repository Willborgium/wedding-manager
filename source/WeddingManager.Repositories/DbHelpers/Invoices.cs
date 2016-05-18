using System.Linq;
using WeddingManager.Core.Data;
using DB = WeddingManager.Entities;

namespace WeddingManager.Repositories.DbHelpers
{
    internal static class Invoices
    {
        internal static DB.Invoice GetInvoice(DB.WeddingManagerEntities entity, int id)
        {
            return entity.Invoices.FirstOrDefault(i => i.Id == id &&
                                                       i.DateSuppressed == null &&
                                                       i.Service.DateSuppressed == null &&
                                                       i.Service.Customer.DateSuppressed == null &&
                                                       i.Service.Customer.Company.DateSuppressed == null);
        }

        internal static Invoice FromDb(DB.Invoice dbInvoice)
        {
            return new Invoice(dbInvoice.Id, dbInvoice.Amount, dbInvoice.Description, dbInvoice.CreatedDate, dbInvoice.DueDate);
        }
    }
}