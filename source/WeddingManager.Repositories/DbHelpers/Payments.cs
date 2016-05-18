using System.Linq;
using WeddingManager.Core.Data;
using DB = WeddingManager.Entities;

namespace WeddingManager.Repositories.DbHelpers
{
    internal static class Payments
    {
        internal static DB.Payment GetPayment(DB.WeddingManagerEntities entity, int id)
        {
            return entity.Payments.FirstOrDefault(p => p.Id == id &&
                                                       p.DateSuppressed == null &&
                                                       p.Service.DateSuppressed == null &&
                                                       p.Service.Customer.DateSuppressed == null &&
                                                       p.Service.Customer.Company.DateSuppressed == null);
        }

        internal static Payment FromDb(DB.Payment dbPayment)
        {
            return new Payment(dbPayment.Id, dbPayment.Amount, (PaymentMethod)dbPayment.PaymentMethodId, dbPayment.DateReceived, dbPayment.Notes);
        }
    }
}