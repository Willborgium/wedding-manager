using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WeddingManager.Api.Models;
using WeddingManager.Core.Services;

namespace WeddingManager.Api.Controllers
{
    [RoutePrefix("api/companies")]
    public class CompanyController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> CreateCompany([FromBody]CompanyDto companyDto)
        {
            var companyId = CompanyService.CreateCompany(companyDto.ToCompany());

            return Ok(companyId);
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> RetrieveCompanies()
        {
            var companies =  CompanyService.RetrieveCompanies();

            return Ok(companies.Select(c => new CompanyDto(c)));
        }

        [HttpPut]
        [Route("")]
        public async Task<IHttpActionResult> UpdateCompany([FromBody]CompanyDto companyDto)
        {
            CompanyService.UpdateCompany(companyDto.ToCompany());

            return Ok();
        }

        [HttpDelete]
        [Route("{companyId}")]
        public async Task<IHttpActionResult> DeleteCompany(int companyId)
        {
            CompanyService.DeleteCompany(companyId);

            return Ok();
        }

        protected ICompanyService CompanyService
        {
            get
            {
                return Services.Resolve<ICompanyService>();
            }
        }
    }
}