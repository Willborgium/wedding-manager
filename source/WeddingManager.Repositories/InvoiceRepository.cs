using System;
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
                var dbService = DbHelpers.Services.GetService(entity, serviceId);

                var dbInvoice = new DB.Invoice
                {
                    Service = dbService,
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
                var dbInvoices = entity.Invoices.Where(i => i.ServiceId == serviceId &&
                                                            i.DateSuppressed == null &&
                                                            i.Service.DateSuppressed == null &&
                                                            i.Service.Customer.DateSuppressed == null &&
                                                            i.Service.Customer.Company.DateSuppressed == null);

                foreach(var dbInvoice in dbInvoices)
                {
                    output.Add(DbHelpers.Invoices.FromDb(dbInvoice));
                }
            }

            return output;
        }

        public void UpdateInvoice(Invoice invoice)
        {
            using (var entity = new DB.WeddingManagerEntities())
            {
                var dbInvoice = DbHelpers.Invoices.GetInvoice(entity, invoice.Id);
                                                                     
                if(dbInvoice != null)
                {
                    dbInvoice.Amount = invoice.Amount;

                    dbInvoice.Description = invoice.Description;

                    dbInvoice.CreatedDate = invoice.CreatedDate;

                    dbInvoice.DueDate = invoice.DueDate;

                    entity.SaveChanges();
                }
            }
        }

        public void DeleteInvoice(int invoiceId)
        {
            using (var entity = new DB.WeddingManagerEntities())
            {
                var dbInvoice = DbHelpers.Invoices.GetInvoice(entity, invoiceId);

                if(dbInvoice != null)
                {
                    dbInvoice.DateSuppressed = DateTime.Now;

                    entity.SaveChanges();
                }
            }
        }
    }
}