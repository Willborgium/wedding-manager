using System;

namespace WeddingManager.Data
{
    public class Expense
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }
    }
}