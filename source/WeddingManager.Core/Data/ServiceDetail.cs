using System;

namespace WeddingManager.Core.Data
{
    public class ServiceDetail
    {
        public int Id { get; private set; }

        public string Details { get; private set; }

        public string Location { get; private set; }

        public DateTime StartTime { get; private set; }

        public DateTime? EndTime { get; private set; }

        public ServiceDetail(int id, string details, string location, DateTime startTime, DateTime? endTime)
        {
            Id = id;

            Details = details;

            Location = location;

            StartTime = startTime;

            EndTime = endTime;
        }
    }
}