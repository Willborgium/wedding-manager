using System.Linq;
using WeddingManager.Core.Data;
using DB = WeddingManager.Entities;

namespace WeddingManager.Repositories.DbHelpers
{
    internal static class Expenses
    {
        internal static DB.Expense GetExpense(DB.WeddingManagerEntities entity, int id)
        {
            return entity.Expenses.FirstOrDefault(e => e.Id == id &&
                                                       e.DateSuppressed == null &&
                                                       e.Company.DateSuppressed == null);
        }

        internal static Expense FromDb(DB.Expense dbExpense)
        {
            return new Expense(dbExpense.Id, dbExpense.Amount, dbExpense.CreatedDate, dbExpense.Description);
        }
    }
}