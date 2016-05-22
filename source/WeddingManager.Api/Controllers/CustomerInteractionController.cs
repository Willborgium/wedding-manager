using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WeddingManager.Api.Models;
using WeddingManager.Core.Services;

namespace WeddingManager.Api.Controllers
{
    [RoutePrefix("api/customerInteractions")]
    public class CustomerInteractionController : ControllerBase
    {
        [HttpOptions]
        [Route("")]
        public async Task<IHttpActionResult> Options()
        {
            return Ok();
        }

        [HttpOptions]
        [Route("{customerId}")]
        public async Task<IHttpActionResult> Options(int customerId)
        {
            return Ok();
        }

        [HttpPost]
        [Route("{customerId}")]
        public async Task<IHttpActionResult> CreateCustomerInteraction(int customerId, [FromBody]CustomerInteractionDto CustomerInteractionDto)
        {
            var customerInteractionId = CustomerInteractionService.CreateCustomerInteraction(customerId, CustomerInteractionDto.ToCustomerInteraction());

            return Ok(customerInteractionId);
        }

        [HttpGet]
        [Route("{customerId}")]
        public async Task<IHttpActionResult> RetrieveCustomerInteractions(int customerId)
        {
            var customerInteractions = CustomerInteractionService.RetrieveCustomerInteractions(customerId)
                                           .Select(c => new CustomerInteractionDto(c));

            return Ok(customerInteractions);
        }

        [HttpPut]
        [Route("")]
        public async Task<IHttpActionResult> UpdateCustomerInteraction([FromBody]CustomerInteractionDto CustomerInteractionDto)
        {
            CustomerInteractionService.UpdateCustomerInteraction(CustomerInteractionDto.ToCustomerInteraction());

            return Ok();
        }

        [HttpDelete]
        [Route("{customerInteractionId}")]
        public async Task<IHttpActionResult> DeleteCustomerInteraction(int customerInteractionId)
        {
            CustomerInteractionService.DeleteCustomerInteraction(customerInteractionId);

            return Ok();
        }

        [HttpGet]
        [Route("types")]
        public async Task<IHttpActionResult> RetrieveCustomerInteractionTypes()
        {
            var customerInteractionTypes = CustomerInteractionService.RetrieveCustomerInteractionTypes();

            return Ok(customerInteractionTypes);
        }

        protected ICustomerInteractionService CustomerInteractionService
        {
            get
            {
                return Services.Resolve<ICustomerInteractionService>();
            }
        }
    }
}