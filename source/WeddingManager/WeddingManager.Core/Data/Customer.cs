using System.Collections.Generic;

namespace WeddingManager.Core.Data
{
    public class Customer
    {
        public Customer(int id, string firstName, string lastName, string phoneNumber)
        {
            Id = id;

            FirstName = firstName;

            LastName = lastName;

            PhoneNumber = phoneNumber;

            Connections = new List<Customer>();

            Services = new List<Service>();
        }

        public int Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string PhoneNumber { get; private set; }

        public List<Customer> Connections { get; private set; }

        public List<Service> Services { get; private set; }
    }
}