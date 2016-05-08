using System.Collections.Generic;
using WeddingManager.Core.Data;

namespace WeddingManager.Core.Repositories
{
    public interface IServiceDetailRepository
    {
        int CreateServiceDetail(int serviceId, ServiceDetail serviceDetail);

        IEnumerable<ServiceDetail> RetrieveServiceDetails(int serviceId);

        void UpdateServiceDetail(ServiceDetail serviceDetail);

        void DeleteServiceDetail(int serviceDetailId);
    }
}