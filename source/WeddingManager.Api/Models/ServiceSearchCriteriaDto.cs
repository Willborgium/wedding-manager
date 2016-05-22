using System;
using WeddingManager.Core.Data;

namespace WeddingManager.Api.Models
{
    public class ServiceSearchCriteriaDto
    {
        public DateTimeOffset? StartDateFrom { get; set; }

        public DateTimeOffset? StartDateTo { get; set; }

        public DateTimeOffset? EndDateFrom { get; set; }

        public DateTimeOffset? EndDateTo { get; set; }

        public string ServiceDescription { get; set; }

        public string ServiceDetailDetails { get; set; }

        public ServiceDetailSearchCriteria ToServiceSearchCriteria()
        {
            return new ServiceDetailSearchCriteria
            {
                StartDateFrom = StartDateFrom,
                StartDateTo = StartDateTo,
                EndDateFrom = EndDateFrom,
                EndDateTo = EndDateTo,
                ServiceDescription = ServiceDescription?.ToLower(),
                ServiceDetailDetails = ServiceDetailDetails?.ToLower()
            };
        }
    }
}