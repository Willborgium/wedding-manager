using System.Collections.Generic;
using WeddingManager.Core.Data;

namespace WeddingManager.Core.Repositories
{
    public interface IServiceRepository
    {
        int CreateService(int customerId, Service service);

        IEnumerable<Service> RetrieveServices(int customerId);

        Service RetrieveService(int companyId, int serviceId);

        void UpdateService(Service service);

        void DeleteService(int serviceId);

        IEnumerable<Service> Search(int companyId, ServiceSearchCriteria searchCriteria);
    }
}