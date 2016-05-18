namespace WeddingManager.Core.Data
{
    public class ServiceDetailSearchResult
    {
        public Service Service { get; }

        public Customer Customer { get; }

        public ServiceDetail ServiceDetail { get; }

        public ServiceDetailSearchResult(Customer customer, Service service, ServiceDetail serviceDetail)
        {
            Customer = customer;

            Service = service;

            ServiceDetail = serviceDetail;
        }
    }
}