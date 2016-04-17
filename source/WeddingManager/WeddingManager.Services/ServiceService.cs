using System.Collections.Generic;
using WeddingManager.Core.Data;
using WeddingManager.Core.Repositories;
using WeddingManager.Core.Services;

namespace WeddingManager.Services
{
    public class ServiceService : IServiceService
    {
        public ServiceService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public int CreateService(int customerId, Service service)
        {
            return _serviceRepository.CreateService(customerId, service);
        }

        public IEnumerable<Service> RetrieveServices(int customerId)
        {
            return _serviceRepository.RetrieveServices(customerId);
        }

        public void UpdateService(Service service)
        {
            _serviceRepository.UpdateService(service);
        }

        public void DeleteService(int serviceId)
        {
            _serviceRepository.DeleteService(serviceId);
        }

        private readonly IServiceRepository _serviceRepository;
    }
}