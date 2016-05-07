using System.Collections.Generic;
using WeddingManager.Core.Data;

namespace WeddingManager.Api.Models
{
    public class ExpensesSummaryDto
    {
        public IDictionary<int, decimal> TotalExpenses { get; set; }

        public ExpensesSummaryDto(ExpensesSummary expensesSummary)
        {
            TotalExpenses = expensesSummary.TotalExpenses;
        }
    }
}