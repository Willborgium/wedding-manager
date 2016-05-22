using System;

namespace WeddingManager.Core.Data
{
    public class ServiceDetailSearchCriteria
    {
        public DateTimeOffset? StartDateFrom { get; set; }

        public DateTimeOffset? StartDateTo { get; set; }

        public DateTimeOffset? EndDateFrom { get; set; }

        public DateTimeOffset? EndDateTo { get; set; }

        public string ServiceDescription { get; set; }

        public string ServiceDetailDetails { get; set; }
    }
}