using System;

namespace WeddingManager.Core.Data
{
    public class CustomerInteraction
    {
        public int Id { get; }

        public CustomerInteractionType InteractionType { get; }

        public DateTimeOffset Date { get; }

        public string Notes { get; }

        public CustomerInteraction(int id, CustomerInteractionType interactionType, DateTimeOffset date, string notes)
        {
            Id = id;

            InteractionType = interactionType;

            Date = date;

            Notes = notes;
        }
    }
}