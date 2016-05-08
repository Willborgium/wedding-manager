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
                var invoices = entity.Invoices.Where(i => i.DateSuppressed == null &&
                                                     i.Service.DateSuppressed == null &&
                                                     i.Service.Customer.DateSuppressed == null &&
                                                     i.Service.Customer.Company.DateSuppressed == null &&
                                                     i.Service.Customer.Company.Id == companyId);
                var expected = 0m;

                if(invoices.Any())
                {
                    expected = invoices.Sum(i => i.Amount);
                }                           

                output.AmountExpectedYearToDate = expected;

                var payments = entity.Payments.Where(p => p.DateSuppressed == null &&
                                                     p.Service.DateSuppressed == null &&
                                                     p.Service.Customer.DateSuppressed == null &&
                                                     p.Service.Customer.Company.DateSuppressed == null &&
                                                     p.Service.Customer.Company.Id == companyId);

                var actual = 0m;

                if (payments.Any())
                {
                    actual = payments.Sum(p => p.Amount);
                }

                output.AmountReceivedYearToDate = actual;

                var start = DateTime.Today;

                var end = start.AddMonths(1);

                var upcoming = entity.Services.Count(s => s.DateSuppressed == null &&
                                                          s.Customer.DateSuppressed == null &&
                                                          s.Customer.Company.DateSuppressed == null &&
                                                          s.Customer.Company.Id == companyId &&
                                                          s.ServiceDetails.Any(sd => start <= sd.StartTime && sd.StartTime <= end));

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