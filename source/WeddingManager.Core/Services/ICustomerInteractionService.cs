using System.Collections.Generic;
using WeddingManager.Core.Data;

namespace WeddingManager.Core.Services
{
    public interface ICustomerInteractionService
    {
        int CreateCustomerInteraction(int customerId, CustomerInteraction customerInteraction);

        IEnumerable<CustomerInteraction> RetrieveCustomerInteractions(int customerId);

        void UpdateCustomerInteraction(CustomerInteraction customerInteraction);

        void DeleteCustomerInteraction(int customerInteractionId);

        IDictionary<string, int> RetrieveCustomerInteractionTypes();
    }
}