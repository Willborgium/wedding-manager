using System.Collections.Generic;
using WeddingManager.Core.Data;
using WeddingManager.Core.Repositories;
using WeddingManager.Core.Services;

namespace WeddingManager.Services
{
    public class ServiceDetailService : IServiceDetailService
    {
        public ServiceDetailService(IServiceDetailRepository serviceDetailRepository)
        {
            _serviceDetailRepository = serviceDetailRepository;
        }

        public int CreateServiceDetail(int serviceId, ServiceDetail serviceDetail)
        {
            return _serviceDetailRepository.CreateServiceDetail(serviceId, serviceDetail);
        }

        public IEnumerable<ServiceDetail> RetrieveServiceDetails(int serviceId)
        {
            return _serviceDetailRepository.RetrieveServiceDetails(serviceId);
        }

        public void UpdateServiceDetail(ServiceDetail serviceDetail)
        {
            _serviceDetailRepository.UpdateServiceDetail(serviceDetail);
        }

        public void DeleteServiceDetail(int serviceDetailId)
        {
            _serviceDetailRepository.DeleteServiceDetail(serviceDetailId);
        }

        public IEnumerable<ServiceDetailSearchResult> Search(int companyId, ServiceDetailSearchCriteria searchCriteria)
        {
            return _serviceDetailRepository.Search(companyId, searchCriteria);
        }

        private readonly IServiceDetailRepository _serviceDetailRepository;
    }
}