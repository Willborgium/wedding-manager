using System.Collections.Generic;

namespace WeddingManager.Data
{
    public class Company
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Customer> Customers { get; set; }

        public List<Expense> Expenses { get; set; }
    }
}