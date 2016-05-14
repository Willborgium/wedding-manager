using System;
using WeddingManager.Core.Data;

namespace WeddingManager.Api.Models
{
    public class ServiceSearchCriteriaDto
    {
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public ServiceSearchCriteria ToServiceSearchCriteria()
        {
            return new ServiceSearchCriteria
            {
                StartDate = StartDate,
                EndDate = EndDate
            };
        }
    }
}