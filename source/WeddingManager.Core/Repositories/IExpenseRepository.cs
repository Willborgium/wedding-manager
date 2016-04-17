using System.Collections.Generic;
using WeddingManager.Core.Data;

namespace WeddingManager.Core.Repositories
{
    public interface IExpenseRepository
    {
        int CreateExpense(int companyId, Expense expense);

        IEnumerable<Expense> RetrieveExpenses(int companyId);

        void UpdateExpense(Expense expense);

        void DeleteExpense(int expenseId);
    }
}
