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
                var dbCompany = entity.Companies.FirstOrDefault(c => c.Id == companyId &&
                                                                   c.DateSuppressed == null);

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
                    output.Add(new Expense(dbExpense.Id, dbExpense.Amount, dbExpense.CreatedDate, dbExpense.Description));
                }
            }

            return output;
        }

        public void UpdateExpense(Expense expense)
        {
            using (var entity = new DB.WeddingManagerEntities())
            {
                var dbExpense = entity.Expenses.FirstOrDefault(e => e.Id == expense.Id &&
                                                                    e.DateSuppressed == null &&
                                                                    e.Company.DateSuppressed == null);
                
                if(dbExpense != null)
                {
                    dbExpense.Amount = expense.Amount;

                    dbExpense.CreatedDate = expense.CreatedDate;

                    dbExpense.Description = expense.Description;
                }

                entity.SaveChanges();
            }
        }

        public void DeleteExpense(int expenseId)
        {
            using (var entity = new DB.WeddingManagerEntities())
            {
                var dbExpense = entity.Expenses.FirstOrDefault(e => e.Id == expenseId &&
                                                                    e.DateSuppressed == null &&
                                                                    e.Company.DateSuppressed == null);

                dbExpense.DateSuppressed = DateTime.Now;

                entity.SaveChanges();
            }
        }
    }
}