using System.Collections.Generic;
using System.Linq;
using WeddingManager.Core.Data;
using WeddingManager.Core.Repositories;
using DB = WeddingManager.Entities;

namespace WeddingManager.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        public int CreateCompanies(Company company)
        {
            using (var entity = new DB.WeddingManagerEntities())
            {
                var dbCompany = new DB.Company
                {
                    Name = company.Name
                };

                entity.Companies.Add(dbCompany);

                entity.SaveChanges();

                return dbCompany.Id;
            }
        }

        public IEnumerable<Company> RetrieveCompanies()
        {
            var output = new List<Company>();

            using (var entity = new DB.WeddingManagerEntities())
            {
                foreach(var company in entity.Companies)
                {
                    output.Add(new Company(company.Id, company.Name));
                }
            }

            return output;
        }

        public void UpdateCompany(Company company)
        {
            using (var entity = new DB.WeddingManagerEntities())
            {
                var dbCompany = entity.Companies.FirstOrDefault(c => c.Id == company.Id);

                if(dbCompany != null)
                {
                    dbCompany.Name = company.Name;
                }

                entity.SaveChanges();
            }
        }

        public void DeleteCompany(int companyId)
        {
            using (var entity = new DB.WeddingManagerEntities())
            {
                var dbCompany = entity.Companies.FirstOrDefault(c => c.Id == companyId);

                // suppress the record...

                entity.SaveChanges();
            }
        }
    }
}