using System;

namespace WeddingManager.Core.Data
{
    public class Invoice
    {
        public Invoice(int id, decimal amount, string description, DateTimeOffset createdDate, DateTimeOffset dueDate)
        {
            Id = id;

            Amount = amount;

            Description = description;

            CreatedDate = createdDate;

            DueDate = dueDate;
        }

        public int Id { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset DueDate { get; set; }
    }
}