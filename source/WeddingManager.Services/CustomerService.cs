using System.Collections.Generic;
using WeddingManager.Core.Data;
using WeddingManager.Core.Repositories;
using WeddingManager.Core.Services;

namespace WeddingManager.Services
{
    public class CustomerService : ICustomerService
    {
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public int CreateCustomer(int companyId, Customer customer)
        {
            return _customerRepository.CreateCustomer(companyId, customer);
        }

        public IEnumerable<Customer> RetrieveCustomers(int companyId)
        {
            return _customerRepository.RetrieveCustomers(companyId);
        }

        public void UpdateCustomer(Customer customer)
        {
            _customerRepository.UpdateCustomer(customer);
        }

        public void DeleteCustomer(int customerId)
        {
            _customerRepository.DeleteCustomer(customerId);
        }

        public CustomersSummary GetSummary(int companyId)
        {
            return _customerRepository.RetrieveSummary(companyId);
        }

        private readonly ICustomerRepository _customerRepository;
    }
}