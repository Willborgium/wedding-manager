using System;
using WeddingManager.Core.Data;

namespace WeddingManager.Api.Models
{
    public class PaymentDto
    {
        public PaymentDto()
        {
        }

        public PaymentDto(Payment payment)
        {
            Id = payment.Id;

            Amount = payment.Amount;

            Method = payment.Method;

            DateReceived = payment.DateReceived;

            Notes = payment.Notes;
        }

        public int Id { get; set; }

        public decimal Amount { get; set; }

        public PaymentMethod Method { get; set; }

        public DateTimeOffset DateReceived { get; set; }

        public string Notes { get; set; }

        public Payment ToPayment()
        {
            return new Payment(Id, Amount, Method, DateReceived, Notes);
        }
    }
}