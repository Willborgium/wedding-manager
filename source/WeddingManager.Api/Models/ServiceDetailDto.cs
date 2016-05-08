using System;
using WeddingManager.Core.Data;

namespace WeddingManager.Api.Models
{
    public class ServiceDetailDto
    {
        public ServiceDetailDto()
        {
        }

        public ServiceDetailDto(ServiceDetail serviceDetail)
        {
            Id = serviceDetail.Id;

            Details = serviceDetail.Details;

            Location = serviceDetail.Location;

            StartTime = serviceDetail.StartTime;

            EndTime = serviceDetail.EndTime;
        }

        public int Id { get; set; }

        public string Details { get; set; }

        public string Location { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public ServiceDetail ToServiceDetail()
        {
            return new ServiceDetail(Id, Details, Location, StartTime, EndTime);
        }
    }
}