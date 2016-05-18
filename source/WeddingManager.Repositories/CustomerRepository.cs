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
                var dbCompany = DbHelpers.Companies.GetCompany(entity, companyId);

                var dbCustomer = new DB.Customer
                {
                    Company = dbCompany,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    PhoneNumber = customer.PhoneNumber,
                    Notes = customer.Notes ?? string.Empty
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
                    output.Add(DbHelpers.Customers.FromDb(dbCustomer));
                }
            }

            return output;
        }

        public void UpdateCustomer(Customer customer)
        {
            using (var entity = new DB.WeddingManagerEntities())
            {
                var dbCustomer = DbHelpers.Customers.GetCustomer(entity, customer.Id);

                if(dbCustomer != null)
                {
                    dbCustomer.FirstName = customer.FirstName;

                    dbCustomer.LastName = customer.LastName;

                    dbCustomer.PhoneNumber = customer.PhoneNumber;

                    dbCustomer.Notes = customer.Notes;

                    entity.SaveChanges();
                }
            }
        }

        public void DeleteCustomer(int customerId)
        {
            using (var entity = new DB.WeddingManagerEntities())
            {
                var dbCustomer = DbHelpers.Customers.GetCustomer(entity, customerId);

                if(dbCustomer != null)
                {
                    dbCustomer.DateSuppressed = DateTime.Now;

                    entity.SaveChanges();
                }
            }
        }
    }
}