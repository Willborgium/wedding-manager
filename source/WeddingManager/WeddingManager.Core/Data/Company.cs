using System.Collections.Generic;

namespace WeddingManager.Core.Data
{
    public class Company
    {
        public Company(int id, string name)
        {
            Id = id;

            Name = name;

            Customers = new List<Customer>();

            Expenses = new List<Expense>();
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public List<Customer> Customers { get; private set; }

        public List<Expense> Expenses { get; private set; }
    }
}