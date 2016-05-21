using System.Collections.Generic;

namespace WeddingManager.Core.Data
{
    public class Customer
    {
        public Customer(int id, string firstName, string lastName, string phoneNumber, string notes)
        {
            Id = id;

            FirstName = firstName;

            LastName = lastName;

            PhoneNumber = phoneNumber;

            Notes = notes;
        }

        public int Id { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string PhoneNumber { get; }

        public string Notes { get; }
    }
}