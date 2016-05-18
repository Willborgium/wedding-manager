using System;
using System.Collections.Generic;
using System.Linq;
using WeddingManager.Core.Data;
using WeddingManager.Core.Repositories;
using DB = WeddingManager.Entities;

namespace WeddingManager.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        public int CreateExpense(int companyId, Expense expense)
        {
            using (var entity = new DB.WeddingManagerEntities())
            {
                var dbCompany = DbHelpers.Companies.GetCompany(entity, companyId);

                var dbExpense = new DB.Expense
                {
                    Company = dbCompany,
                    Amount = expense.Amount,
                    CreatedDate = expense.CreatedDate,
                    Description = expense.Description
                };

                entity.Expenses.Add(dbExpense);

                entity.SaveChanges();

                return dbExpense.Id;
            }
        }

        public IEnumerable<Expense> RetrieveExpenses(int companyId)
        {
            var output = new List<Expense>();

            using (var entity = new DB.WeddingManagerEntities())
            {
                var dbExpenses = entity.Expenses.Where(e => e.CompanyId == companyId &&
                                                            e.DateSuppressed == null &&
                                                            e.Company.DateSuppressed == null);

                foreach(var dbExpense in dbExpenses)
                {
                    output.Add(DbHelpers.Expenses.FromDb(dbExpense));
                }
            }

            return output;
        }

        public void UpdateExpense(Expense expense)
        {
            using (var entity = new DB.WeddingManagerEntities())
            {
                var dbExpense = DbHelpers.Expenses.GetExpense(entity, expense.Id);
                
                if(dbExpense != null)
                {
                    dbExpense.Amount = expense.Amount;

                    dbExpense.CreatedDate = expense.CreatedDate;

                    dbExpense.Description = expense.Description;

                    entity.SaveChanges();
                }
            }
        }

        public void DeleteExpense(int expenseId)
        {
            using (var entity = new DB.WeddingManagerEntities())
            {
                var dbExpense = DbHelpers.Expenses.GetExpense(entity, expenseId);

                if(dbExpense != null)
                {
                    dbExpense.DateSuppressed = DateTime.Now;

                    entity.SaveChanges();
                }
            }
        }
    }
}