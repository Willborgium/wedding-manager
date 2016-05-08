using System.Collections.Generic;
using WeddingManager.Core.Data;

namespace WeddingManager.Core.Repositories
{
    public interface ICompanyRepository
    {
        int CreateCompany(Company company);

        IEnumerable<Company> RetrieveCompanies();

        void UpdateCompany(Company company);

        void DeleteCompany(int companyId);
    }
}