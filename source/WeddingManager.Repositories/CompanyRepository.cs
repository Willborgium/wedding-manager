using System;
using System.Collections.Generic;
using System.Linq;
using WeddingManager.Core.Data;
using WeddingManager.Core.Repositories;
using DB = WeddingManager.Entities;

namespace WeddingManager.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        public int CreateCompany(Company company)
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
                var dbCompanies = entity.Companies.Where(c => c.DateSuppressed == null);

                foreach(var dbCompany in dbCompanies)
                {
                    output.Add(DbHelpers.Companies.FromDb(dbCompany));
                }
            }

            return output;
        }

        public void UpdateCompany(Company company)
        {
            using (var entity = new DB.WeddingManagerEntities())
            {
                var dbCompany = DbHelpers.Companies.GetCompany(entity, company.Id);

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
                var dbCompany = DbHelpers.Companies.GetCompany(entity, companyId);

                dbCompany.DateSuppressed = DateTime.Now;

                entity.SaveChanges();
            }
        }
    }
}