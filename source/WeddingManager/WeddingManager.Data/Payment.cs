using System;

namespace WeddingManager.Data
{
    public class Payment
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public PaymentMethod Method { get; set; }

        public DateTime DateReceived { get; set; }

        public string Notes { get; set; }
    }
}