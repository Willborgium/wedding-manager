using System;
using System.Collections.Generic;

namespace WeddingManager.Core.Data
{
    public class Service
    {
        public Service(int id, string description, string location, DateTime startTime, DateTime? endTime)
        {
            Id = id;

            Description = description;

            Location = location;

            StartTime = startTime;

            EndTime = endTime;

            Invoices = new List<Invoice>();

            Payments = new List<Payment>();
        }

        public int Id { get; private set; }

        public string Description { get; private set; }

        public string Location { get; private set; }

        public DateTime StartTime { get; private set; }

        public DateTime? EndTime { get; private set; }

        public List<Invoice> Invoices { get; set; }

        public List<Payment> Payments { get; set; }
    }
}