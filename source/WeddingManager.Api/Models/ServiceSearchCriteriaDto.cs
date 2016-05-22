using System;
using WeddingManager.Core.Data;

namespace WeddingManager.Api.Models
{
    public class ServiceSearchCriteriaDto
    {
        public DateTimeOffset? StartDate { get; set; }

        public DateTimeOffset? EndDate { get; set; }

        public string ServiceDescription { get; set; }

        public string ServiceDetailDetails { get; set; }

        public ServiceDetailSearchCriteria ToServiceSearchCriteria()
        {
            return new ServiceDetailSearchCriteria
            {
                StartDate = StartDate,
                EndDate = EndDate,
                ServiceDescription = ServiceDescription?.ToLower(),
                ServiceDetailDetails = ServiceDetailDetails?.ToLower()
            };
        }
    }
}