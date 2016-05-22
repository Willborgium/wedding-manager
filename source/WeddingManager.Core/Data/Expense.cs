using System;

namespace WeddingManager.Core.Data
{
    public class Expense
    {
        public Expense(int id, decimal amount, DateTimeOffset createdDate, string description)
        {
            Id = id;

            Amount = amount;

            CreatedDate = createdDate;

            Description = description;
        }

        public int Id { get; private set; }

        public decimal Amount { get; private set; }

        public DateTimeOffset CreatedDate { get; private set; }

        public string Description { get; private set; }
    }
}