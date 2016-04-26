using System;
using System.Collections.Generic;
using System.Linq;
using WeddingManager.Core.Data;
using WeddingManager.Core.Repositories;
using DB = WeddingManager.Entities;

namespace WeddingManager.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public int CreateCustomer(int companyId, Customer customer)
        {
            using (var entity = new DB.WeddingManagerEntities())
            {
                var dbCompany = entity.Companies.FirstOrDefault(c => c.Id == companyId &&
                                                                   c.DateSuppressed == null);

                var dbCustomer = new DB.Customer
                {
                    Company = dbCompany,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    PhoneNumber = customer.PhoneNumber
                };

                entity.Customers.Add(dbCustomer);

                entity.SaveChanges();

                return dbCustomer.Id;
            }
        }

        public IEnumerable<Customer> RetrieveCustomers(int companyId)
        {
            var output = new List<Customer>();

            using (var entity = new DB.WeddingManagerEntities())
            {
                var dbCustomers = entity.Customers.Where(c => c.CompanyId == companyId &&
                                                              c.DateSuppressed == null &&
                                                              c.Company.DateSuppressed == null);

                foreach(var dbCustomer in dbCustomers)
                {
                    output.Add(new Customer(dbCustomer.Id, dbCustomer.FirstName, dbCustomer.LastName, dbCustomer.PhoneNumber));
                }

                entity.SaveChanges();
            }

            return output;
        }

        public void UpdateCustomer(Customer customer)
        {
            using (var entity = new DB.WeddingManagerEntities())
            {
                var dbCustomer = entity.Customers.FirstOrDefault(c => c.Id == customer.Id &&
                                                                      c.DateSuppressed == null &&
                                                                      c.Company.DateSuppressed == null);

                if(dbCustomer != null)
                {
                    dbCustomer.FirstName = customer.FirstName;

                    dbCustomer.LastName = customer.LastName;

                    dbCustomer.PhoneNumber = customer.PhoneNumber;
                }

                entity.SaveChanges();
            }
        }

        public void DeleteCustomer(int customerId)
        {
            using (var entity = new DB.WeddingManagerEntities())
            {
                var dbCustomer = entity.Customers.FirstOrDefault(c => c.Id == customerId &&
                                                                      c.DateSuppressed == null);
                dbCustomer.DateSuppressed = DateTime.Now;

                entity.SaveChanges();
            }
        }

        public CustomersSummary RetrieveSummary(int companyId)
        {
            var output = new CustomersSummary();

            using (var entity = new DB.WeddingManagerEntities())
            {
                var expected = entity.Invoices.Where(i => i.DateSuppressed == null &&
                                                     i.Service.DateSuppressed == null &&
                                                     i.Service.Customer.DateSuppressed == null &&
                                                     i.Service.Customer.Company.DateSuppressed == null &&
                                                     i.Service.Customer.Company.Id == companyId)
                                              .Sum(i => i.Amount);

                var actual = entity.Payments.Where(p => p.DateSuppressed == null &&
                                                   p.Service.DateSuppressed == null &&
                                                   p.Service.Customer.DateSuppressed == null &&
                                                   p.Service.Customer.Company.DateSuppressed == null &&
                                                   p.Service.Customer.Company.Id == companyId)
                                            .Sum(p => p.Amount);

                var start = DateTime.Today;

                var end = start.AddMonths(1);

                var upcoming = entity.Services.Count(s => s.DateSuppressed == null &&
                                                          s.Customer.DateSuppressed == null &&
                                                          s.Customer.Company.DateSuppressed == null &&
                                                          s.Customer.Company.Id == companyId &&
                                                          s.StartTime >= start && s.StartTime <= end);

                output.AmountExpectedYTD = expected;

                output.AmountReceivedYTD = actual;

                output.UpcomingAppointmentCount = upcoming;

            }

            return output;
        }
    }
}