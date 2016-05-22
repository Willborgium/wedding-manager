using System;

namespace WeddingManager.Core.Data
{
    public class ServiceDetailSearchCriteria
    {
        public DateTimeOffset? StartDate { get; set; }

        public DateTimeOffset? EndDate { get; set; }
        
        public string ServiceDescription { get; set; }

        public string ServiceDetailDetails { get; set; }
    }
}