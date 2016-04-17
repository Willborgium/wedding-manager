using System.Collections.Generic;
using WeddingManager.Core.Data;

namespace WeddingManager.Core.Services
{
    public interface ICompanyService
    {
        IEnumerable<Company> RetrieveCompanies();

        int CreateCompany(Company company);

        void UpdateCompany(Company company);

        void DeleteCompany(int companyId);
    }
}