using System;
using System.Collections.Generic;
using System.Linq;
using WeddingManager.Core.Data;
using WeddingManager.Core.Repositories;
using DB = WeddingManager.Entities;

namespace WeddingManager.Repositories
{
    public class SummaryRepository : ISummaryRepository
    {
        public CompanySummary RetrieveCompanySummary(int companyId)
        {
            var output = new CompanySummary();

            using (var entity = new DB.WeddingManagerEntities())
            {

                var expected = entity.Invoices.Where(i => i.DateSuppressed == null &&
                                                     i.Service.DateSuppressed == null &&
                                                     i.Service.Customer.DateSuppressed == null &&
                                                     i.Service.Customer.Company.DateSuppressed == null &&
                                                     i.Service.Customer.Company.Id == companyId)
                                              .Sum(i => i.Amount);

                output.AmountExpectedYearToDate = expected;

                var actual = entity.Payments.Where(p => p.DateSuppressed == null &&
                                                   p.Service.DateSuppressed == null &&
                                                   p.Service.Customer.DateSuppressed == null &&
                                                   p.Service.Customer.Company.DateSuppressed == null &&
                                                   p.Service.Customer.Company.Id == companyId)
                                            .Sum(p => p.Amount);

                output.AmountReceivedYearToDate = actual;

                var start = DateTime.Today;

                var end = start.AddMonths(1);

                var upcoming = entity.Services.Count(s => s.DateSuppressed == null &&
                                                          s.Customer.DateSuppressed == null &&
                                                          s.Customer.Company.DateSuppressed == null &&
                                                          s.Customer.Company.Id == companyId &&
                                                          s.StartTime >= start && s.StartTime <= end);

                output.UpcomingAppointmentCount = upcoming;
            }

            return output;
        }

        public ExpensesSummary RetrieveExpensesSummary(int companyId)
        {
            var totalExpenses = new Dictionary<int, decimal>();

            using (var entity = new DB.WeddingManagerEntities())
            {
                foreach(var expense in entity.Expenses)
                {
                    if (!totalExpenses.ContainsKey(expense.CreatedDate.Year))
                    {
                        totalExpenses.Add(expense.CreatedDate.Year, 0);
                    }

                    totalExpenses[expense.CreatedDate.Year] += expense.Amount;
                }
            }

            return new ExpensesSummary
            {
                TotalExpenses = totalExpenses
            };
        }
    }
}