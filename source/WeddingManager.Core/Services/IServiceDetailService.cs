using System.Collections.Generic;
using WeddingManager.Core.Data;

namespace WeddingManager.Core.Services
{
    public interface IServiceDetailService
    {
        int CreateServiceDetail(int serviceId, ServiceDetail serviceDetail);

        IEnumerable<ServiceDetail> RetrieveServiceDetails(int serviceId);

        void UpdateServiceDetail(ServiceDetail serviceDetail);

        void DeleteServiceDetail(int serviceDetailId);

        IEnumerable<ServiceDetailSearchResult> Search(int companyId, ServiceDetailSearchCriteria searchCriteria);
    }
}