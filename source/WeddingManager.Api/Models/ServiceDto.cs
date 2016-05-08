using WeddingManager.Core.Data;

namespace WeddingManager.Api.Models
{
    public class ServiceDto
    {
        public ServiceDto()
        {
        }

        public ServiceDto(Service service)
        {
            Id = service.Id;

            Description = service.Description;
        }
        
        public int Id { get; set; }

        public string Description { get; set; }

        public Service ToService()
        {
            return new Service(Id, Description);
        }
    }
}