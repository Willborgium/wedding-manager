using System;
using WeddingManager.Core.Data;

namespace WeddingManager.Api.Models
{
    public class InvoiceDto
    {
        public InvoiceDto()
        {
        }

        public InvoiceDto(Invoice invoice)
        {
            Id = invoice.Id;

            Amount = invoice.Amount;

            Description = invoice.Description;

            CreatedDate = invoice.CreatedDate;

            DueDate = invoice.DueDate;
        }

        public int Id { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset DueDate { get; set; }

        public Invoice ToInvoice()
        {
            return new Invoice(Id, Amount, Description, CreatedDate, DueDate);
        }
    }
}