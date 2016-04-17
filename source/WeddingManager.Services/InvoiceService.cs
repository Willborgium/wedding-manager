using System.Collections.Generic;
using WeddingManager.Core.Data;
using WeddingManager.Core.Repositories;
using WeddingManager.Core.Services;

namespace WeddingManager.Services
{
    public class InvoiceService : IInvoiceService
    {
        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public int CreateInvoice(int serviceId, Invoice invoice)
        {
            return _invoiceRepository.CreateInvoice(serviceId, invoice);
        }

        public IEnumerable<Invoice> RetrieveInvoices(int serviceId)
        {
            return _invoiceRepository.RetrieveInvoices(serviceId);
        }

        public void UpdateInvoice(Invoice invoice)
        {
            _invoiceRepository.UpdateInvoice(invoice);
        }

        public void DeleteInvoice(int invoiceId)
        {
            _invoiceRepository.DeleteInvoice(invoiceId);
        }

        private readonly IInvoiceRepository _invoiceRepository;
    }
}