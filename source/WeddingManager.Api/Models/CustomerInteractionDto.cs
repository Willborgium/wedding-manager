using System;
using WeddingManager.Core.Data;

namespace WeddingManager.Api.Models
{
    public class CustomerInteractionDto
    {
        public int Id { get; set; }

        public CustomerInteractionTypeDto InteractionType { get; set; }

        public DateTime Date { get; set; }

        public string Notes { get; set; }

        public CustomerInteractionDto()
        {
        }

        public CustomerInteractionDto(CustomerInteraction customerInteraction)
        {
            Id = customerInteraction.Id;

            InteractionType = (CustomerInteractionTypeDto)customerInteraction.InteractionType;

            Date = customerInteraction.Date;

            Notes = customerInteraction.Notes;
        }

        public CustomerInteraction ToCustomerInteraction()
        {
            return new CustomerInteraction(Id, (CustomerInteractionType)InteractionType, Date.Date, Notes);
        }
    }
}