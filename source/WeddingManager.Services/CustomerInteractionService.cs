using System.Collections.Generic;
using WeddingManager.Core.Data;
using WeddingManager.Core.Repositories;
using WeddingManager.Core.Services;

namespace WeddingManager.Services
{
    public class CustomerInteractionService : ICustomerInteractionService
    {
        public CustomerInteractionService(ICustomerInteractionRepository customerInteractionRepository)
        {
            _customerInteractionRepository = customerInteractionRepository;
        }

        public int CreateCustomerInteraction(int customerId, CustomerInteraction customerInteraction)
        {
            return _customerInteractionRepository.CreateCustomerInteraction(customerId, customerInteraction);
        }

        public IEnumerable<CustomerInteraction> RetrieveCustomerInteractions(int customerId)
        {
            return _customerInteractionRepository.RetrieveCustomerInteractions(customerId);
        }

        public void UpdateCustomerInteraction(CustomerInteraction customerInteraction)
        {
            _customerInteractionRepository.UpdateCustomerInteraction(customerInteraction);
        }

        public void DeleteCustomerInteraction(int customerInteractionId)
        {
            _customerInteractionRepository.DeleteCustomerInteraction(customerInteractionId);
        }

        public IDictionary<int, string> RetrieveCustomerInteractionTypes()
        {
            return _customerInteractionRepository.RetrieveCustomerInteractionTypes();
        }

        private readonly ICustomerInteractionRepository _customerInteractionRepository;
    }
}