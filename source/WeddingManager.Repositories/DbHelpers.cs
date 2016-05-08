using System.Linq;
using DB = WeddingManager.Entities;

namespace WeddingManager.Repositories
{
    internal static class DbHelpers
    {
        public static DB.Company GetCompany(DB.WeddingManagerEntities entity, int id)
        {
            return entity.Companies.FirstOrDefault(c => c.Id == id &&
                                                        c.DateSuppressed == null);
        }

        public static DB.Expense GetExpense(DB.WeddingManagerEntities entity, int id)
        {
            return entity.Expenses.FirstOrDefault(e => e.Id == id &&
                                                       e.DateSuppressed == null &&
                                                       e.Company.DateSuppressed == null);
        }

        public static DB.Customer GetCustomer(DB.WeddingManagerEntities entity, int id)
        {
            return entity.Customers.FirstOrDefault(c => c.Id == id &&
                                                        c.DateSuppressed == null &&
                                                        c.Company.DateSuppressed == null);
        }

        public static DB.Service GetService(DB.WeddingManagerEntities entity, int id)
        {
            return entity.Services.FirstOrDefault(s => s.Id == id &&
                                                       s.DateSuppressed == null &&
                                                       s.Customer.DateSuppressed == null &&
                                                       s.Customer.Company.DateSuppressed == null);
        }

        public static DB.ServiceDetail GetServiceDetail(DB.WeddingManagerEntities entity, int id)
        {
            return entity.ServiceDetails.FirstOrDefault(sd => sd.Id == id &&
                                                              sd.DateSuppressed == null &&
                                                              sd.Service.DateSuppressed == null &&
                                                              sd.Service.Customer.DateSuppressed == null &&
                                                              sd.Service.Customer.Company.DateSuppressed == null);
        }

        public static DB.Payment GetPayment(DB.WeddingManagerEntities entity, int id)
        {
            return entity.Payments.FirstOrDefault(p => p.Id == id &&
                                                       p.DateSuppressed == null &&
                                                       p.Service.DateSuppressed == null &&
                                                       p.Service.Customer.DateSuppressed == null &&
                                                       p.Service.Customer.Company.DateSuppressed == null);
        }

        public static DB.Invoice GetInvoice(DB.WeddingManagerEntities entity, int id)
        {
            return entity.Invoices.FirstOrDefault(i => i.Id == id &&
                                                       i.DateSuppressed == null &&
                                                       i.Service.DateSuppressed == null &&
                                                       i.Service.Customer.DateSuppressed == null &&
                                                       i.Service.Customer.Company.DateSuppressed == null);
        }
    }
}