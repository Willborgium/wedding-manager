using WeddingManager.Core.Data;

namespace WeddingManager.Api.Models
{
    public class CustomerDto
    {
        public CustomerDto()
        {
        }

        public CustomerDto(Customer customer)
        {
            Id = customer.Id;

            FirstName = customer.FirstName;

            LastName = customer.LastName;

            PhoneNumber = customer.PhoneNumber;
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public Customer ToCustomer()
        {
            return new Customer(Id, FirstName, LastName, PhoneNumber);
        }
    }
}