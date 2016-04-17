using System.Collections.Generic;

namespace WeddingManager.Data
{
    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public List<Customer> Connections { get; set; }

        public List<Service> Services { get; set; }
    }
}