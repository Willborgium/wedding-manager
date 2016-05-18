using WeddingManager.Core.Data;

namespace WeddingManager.Api.Models
{
    public class ServiceDetailSearchResultDto
    {
        public CustomerDto Customer { get; }

        public ServiceDto Service { get; }

        public ServiceDetailDto ServiceDetail { get; }

        public ServiceDetailSearchResultDto(ServiceDetailSearchResult data)
        {
            Customer = new CustomerDto(data.Customer);

            Service = new ServiceDto(data.Service);

            ServiceDetail = new ServiceDetailDto(data.ServiceDetail);
        }
    }
}