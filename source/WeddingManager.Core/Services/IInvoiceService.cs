using System.Collections.Generic;
using WeddingManager.Core.Data;

namespace WeddingManager.Core.Services
{
    public interface IInvoiceService
    {
        int CreateInvoice(int serviceId, Invoice invoice);

        IEnumerable<Invoice> RetrieveInvoices(int serviceId);

        void UpdateInvoice(Invoice invoice);

        void DeleteInvoice(int invoiceId);
    }
}