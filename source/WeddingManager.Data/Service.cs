using System;
using System.Collections.Generic;

namespace WeddingManager.Data
{
    public class Service
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public List<Invoice> Invoices { get; set; }

        public List<Payment> Payments { get; set; }
    }
}