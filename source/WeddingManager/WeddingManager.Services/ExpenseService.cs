using System.Collections.Generic;
using WeddingManager.Core.Data;
using WeddingManager.Core.Repositories;
using WeddingManager.Core.Services;

namespace WeddingManager.Services
{
    public class ExpenseService : IExpenseService
    {
        public ExpenseService(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public int CreateExpense(int companyId, Expense expense)
        {
            return _expenseRepository.CreateExpense(companyId, expense);
        }

        public IEnumerable<Expense> RetrieveExpenses(int companyId)
        {
            return _expenseRepository.RetrieveExpenses(companyId);
        }

        public void UpdateExpense(Expense expense)
        {
            _expenseRepository.UpdateExpense(expense);
        }

        public void DeleteExpense(int expenseId)
        {
            _expenseRepository.DeleteExpense(expenseId);
        }

        private readonly IExpenseRepository _expenseRepository;
    }
}