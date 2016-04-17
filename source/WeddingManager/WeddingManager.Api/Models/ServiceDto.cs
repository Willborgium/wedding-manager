using System;
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

            Location = service.Location;

            StartTime = service.StartTime;

            EndTime = service.EndTime;
        }
        
        public int Id { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public Service ToService()
        {
            return new Service(Id, Description, Location, StartTime, EndTime);
        }
    }
}