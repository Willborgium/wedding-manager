using System;
using WeddingManager.Core.Data;

namespace WeddingManager.Api.Models
{
    public class ExpenseDto
    {
        public ExpenseDto()
        {
        }

        public ExpenseDto(Expense expense)
        {
            Id = expense.Id;

            Amount = expense.Amount;

            CreatedDate = expense.CreatedDate;

            Description = expense.Description;
        }

        public int Id { get; set; }

        public decimal Amount { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Description { get; set; }

        public Expense ToExpense()
        {
            return new Expense(Id, Amount, CreatedDate, Description);
        }
    }
}