using System;
using WeddingManager.Core.Data;

namespace WeddingManager.Api.Models
{
    public class ServiceSearchCriteriaDto
    {
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public ServiceDetailSearchCriteria ToServiceSearchCriteria()
        {
            return new ServiceDetailSearchCriteria
            {
                StartDate = StartDate,
                EndDate = EndDate
            };
        }
    }
}