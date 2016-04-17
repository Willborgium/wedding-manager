using System.Collections.Generic;
using System.Linq;
using WeddingManager.Core.Data;
using WeddingManager.Core.Repositories;
using DB = WeddingManager.Entities;

namespace WeddingManager.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        public int CreateInvoice(int serviceId, Invoice invoice)
        {
            using (var entity = new DB.WeddingManagerEntities())
            {
                var dbInvoice = new DB.Invoice
                {
                    ServiceId = serviceId,
                    Amount = invoice.Amount,
                    Description = invoice.Description,
                    CreatedDate = invoice.CreatedDate,
                    DueDate = invoice.DueDate
                };

                entity.Invoices.Add(dbInvoice);

                entity.SaveChanges();

                return dbInvoice.Id;
            }
        }

        public IEnumerable<Invoice> RetrieveInvoices(int serviceId)
        {
            var output = new List<Invoice>();

            using (var entity = new DB.WeddingManagerEntities())
            {
                var invoices = entity.Invoices.Where(i => i.ServiceId == serviceId);

                foreach(var invoice in invoices)
                {
                    output.Add(new Invoice(invoice.Id, invoice.Amount, invoice.Description, invoice.CreatedDate, invoice.DueDate));
                }
            }

            return output;
        }

        public void UpdateInvoice(Invoice invoice)
        {
            using (var entity = new DB.WeddingManagerEntities())
            {
                var dbInvoice = entity.Invoices.FirstOrDefault(i => i.Id == invoice.Id);

                if(dbInvoice != null)
                {
                    dbInvoice.Amount = invoice.Amount;

                    dbInvoice.Description = invoice.Description;

                    dbInvoice.CreatedDate = invoice.CreatedDate;

                    dbInvoice.DueDate = invoice.DueDate;
                }

                entity.SaveChanges();
            }
        }

        public void DeleteInvoice(int invoiceId)
        {
            using (var entity = new DB.WeddingManagerEntities())
            {
                var dbInvoice = entity.Invoices.FirstOrDefault(i => i.Id == invoiceId);

                // suppress record

                entity.SaveChanges();
            }
        }
    }
}