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
                var dbCustomer = new DB.Customer
                {
                    CompanyId = companyId,
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
                var dbCustomers = entity.Customers.Where(c => c.CompanyId == companyId);

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
                var dbCustomer = entity.Customers.FirstOrDefault(c => c.Id == customer.Id);

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
                var dbCustomer = entity.Customers.FirstOrDefault(c => c.Id == customerId);

                // suppress record

                entity.SaveChanges();
            }
        }
    }
}