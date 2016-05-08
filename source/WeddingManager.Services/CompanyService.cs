using System.Collections.Generic;
using WeddingManager.Core.Data;
using WeddingManager.Core.Repositories;
using WeddingManager.Core.Services;

namespace WeddingManager.Services
{
    public class CompanyService : ICompanyService
    {
        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public IEnumerable<Company> RetrieveCompanies()
        {
            return _companyRepository.RetrieveCompanies();
        }

        public int CreateCompany(Company company)
        {
            return _companyRepository.CreateCompany(company);
        }

        public void UpdateCompany(Company company)
        {
            _companyRepository.UpdateCompany(company);
        }

        public void DeleteCompany(int companyId)
        {
            _companyRepository.DeleteCompany(companyId);
        }

        private readonly ICompanyRepository _companyRepository;
    }
}