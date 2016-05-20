using System;

namespace WeddingManager.Core.Data
{
    public class ServiceDetailSearchCriteria
    {
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
        
        public string ServiceDescription { get; set; }

        public string ServiceDetailDetails { get; set; }
    }
}