using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WeddingManager.Api.Models;
using WeddingManager.Core.Services;

namespace WeddingManager.Api.Controllers
{
    [RoutePrefix("api/customers")]
    public class CustomerController : ControllerBase
    {
        [HttpPost]
        [Route("{companyId}")]
        public async Task<IHttpActionResult> CreateCustomer(int companyId, [FromBody]CustomerDto customerDto)
        {
            var customerId = CustomerService.CreateCustomer(companyId, customerDto.ToCustomer());

            return Ok(customerId);
        }

        [HttpGet]
        [Route("{companyId}")]
        public async Task<IHttpActionResult> RetrieveCustomers(int companyId)
        {
            var customers = CustomerService.RetrieveCustomers(companyId).Select(c => new CustomerDto(c));

            return Ok(customers);
        }

        [HttpPut]
        [Route("")]
        public async Task<IHttpActionResult> UpdateCustomer([FromBody]CustomerDto customerDto)
        {
            CustomerService.UpdateCustomer(customerDto.ToCustomer());

            return Ok();
        }

        [HttpDelete]
        [Route("{customerId}")]
        public async Task<IHttpActionResult> DeleteCustomer(int customerId)
        {
            CustomerService.DeleteCustomer(customerId);

            return Ok();
        }

        protected ICustomerService CustomerService
        {
            get
            {
                return Services.Resolve<ICustomerService>();
            }
        }
    }
}